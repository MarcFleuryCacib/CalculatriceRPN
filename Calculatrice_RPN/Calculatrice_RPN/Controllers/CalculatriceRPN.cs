using Microsoft.AspNetCore.Mvc;

namespace Calculatrice_RPN.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CalculatriceRPN : ControllerBase
    {
        // Variable statique pour stocker la pile
        private static readonly Stack<double> pile = new Stack<double>();

        // Classe pour représenter les éléments de la pile avec les indices
        public class PileElement
        {
            public int Index { get; set; }
            public double Value { get; set; }
        }

        // Endpoint pour ajouter un élément dans la pile
        [HttpPost("PUSH")]
        public ActionResult AjouterElement([FromBody] double nombre)
        {
            lock (pile)
            {
                // Ajout de l'élément à la pile
                pile.Push(nombre);

                // Réponse de succès avec message
                var successResponse = new
                {
                    message = "Élément ajouté avec succès.",
                    value = nombre, // Valeur ajoutée
                    //pile = pile.ToArray() // Contenu actuel de la pile
                };

                // Renvoie une réponse HTTP 200 (OK) avec le message personnalisé et le contenu de la pile
                return Ok(successResponse);
            }
        }

        // Endpoint pour récupérer la pile avec les indices
        [HttpGet("PILE")]
        public ActionResult<IEnumerable<PileElement>> GetPileWithIndices()
        {
            lock (pile)
            {
                // Convertit la pile en une liste d'objets PileElement pour le renvoyer sous forme de réponse JSON
                var pileList = pile.Select((value, index) => new PileElement { Index = index, Value = value }).ToList();
                return Ok(pileList);
            }
        }
    }
}