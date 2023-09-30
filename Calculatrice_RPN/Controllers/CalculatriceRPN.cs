using Microsoft.AspNetCore.Mvc;

namespace Calculatrice_RPN.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CalculatriceRPN : ControllerBase
    {
        // Variable statique pour stocker la pile
        private static readonly Stack<double> pile = new Stack<double>();

        // Classe pour repr�senter les �l�ments de la pile avec les indices
        public class PileElement
        {
            public int Index { get; set; }
            public double Value { get; set; }
        }

        // Endpoint pour ajouter un �l�ment dans la pile
        [HttpPost("PUSH")]
        public ActionResult AjouterElement([FromBody] double nombre)
        {
            lock (pile)
            {
                // Ajout de l'�l�ment � la pile
                pile.Push(nombre);

                // R�ponse de succ�s avec message
                var successResponse = new
                {
                    message = "�l�ment ajout� avec succ�s.",
                    value = nombre, // Valeur ajout�e
                    //pile = pile.ToArray() // Contenu actuel de la pile
                };

                // Renvoie une r�ponse HTTP 200 (OK) avec le message personnalis� et le contenu de la pile
                return Ok(successResponse);
            }
        }

        // Endpoint pour r�cup�rer la pile avec les indices
        [HttpGet("PILE")]
        public ActionResult<IEnumerable<PileElement>> GetPileWithIndices()
        {
            lock (pile)
            {
                // Convertit la pile en une liste d'objets PileElement pour le renvoyer sous forme de r�ponse JSON
                var pileList = pile.Select((value, index) => new PileElement { Index = index, Value = value }).ToList();
                return Ok(pileList);
            }
        }

        // Endpoint pour nettoyer la pile
        [HttpDelete("CLEAN")]
        public ActionResult NettoyerPile()
        {
            lock (pile)
            {
                // Nettoie la pile
                pile.Clear();

                // R�ponse de succ�s avec message
                var successResponse = new
                {
                    message = "La pile a �t� nettoy�e avec succ�s."
                };

                // Renvoie une r�ponse HTTP 200 (OK) avec le message personnalis�
                return Ok(successResponse);
            }
        }

        // Endpoint pour supprimer le dernier de la pile
        [HttpPost("DELETELAST")]
        public ActionResult SuppLastPile()
        {
            lock (pile)
            {
                // Nettoie la pile
                double a = pile.Pop();

                // R�ponse de succ�s avec message
                var successResponse = new
                {
                    message = "La dernier element de la liste a �t� nettoy�e avec succ�s.",
                    value = a,
                };

                // Renvoie une r�ponse HTTP 200 (OK) avec le message personnalis�
                return Ok(successResponse);
            }
        }
    }
}