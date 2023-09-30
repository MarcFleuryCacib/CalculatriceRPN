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

        // Endpoint pour nettoyer la pile
        [HttpDelete("CLEAN")]
        public ActionResult NettoyerPile()
        {
            lock (pile)
            {
                // Nettoie la pile
                pile.Clear();

                // Réponse de succès avec message
                var successResponse = new
                {
                    message = "La pile a été nettoyée avec succès."
                };

                // Renvoie une réponse HTTP 200 (OK) avec le message personnalisé
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

                // Réponse de succès avec message
                var successResponse = new
                {
                    message = "La dernier element de la liste a été nettoyée avec succès.",
                    value = a,
                };

                // Renvoie une réponse HTTP 200 (OK) avec le message personnalisé
                return Ok(successResponse);
            }
        }


        // Endpoint pour effectuer l'opération d'addition
        [HttpPost("ADD")]
        public ActionResult<double> Addition()
        {
            lock (pile)
            {
                if (pile.Count < 2)
                {
                    // Erreur : Pas assez d'éléments dans la pile pour effectuer l'addition
                    return BadRequest("Il n'y a pas assez d'éléments dans la pile pour effectuer l'addition.");
                }

                double a = pile.Pop();
                double b = pile.Pop();
                double resultat = a + b;
                pile.Push(resultat);

                // Réponse de succès avec le résultat de l'addition
                return Ok(resultat);
            }
        }

        // Endpoint pour effectuer l'opération de soustraction
        [HttpPost("SUBTRACTION")]
        public ActionResult<double> Soustraction()
        {
            lock (pile)
            {
                if (pile.Count < 2)
                {
                    // Erreur : Pas assez d'éléments dans la pile pour effectuer la soustraction
                    return BadRequest("Il n'y a pas assez d'éléments dans la pile pour effectuer la soustraction.");
                }

                double a = pile.Pop();
                double b = pile.Pop();
                double resultat = b - a;
                pile.Push(resultat);

                // Réponse de succès avec le résultat de la soustraction
                return Ok(resultat);
            }
        }

        // Endpoint pour effectuer l'opération de multiplication
        [HttpPost("MULTIPLICATION")]
        public ActionResult<double> Multiplication()
        {
            lock (pile)
            {
                if (pile.Count < 2)
                {
                    // Erreur : Pas assez d'éléments dans la pile pour effectuer la multiplication
                    return BadRequest("Il n'y a pas assez d'éléments dans la pile pour effectuer la multiplication.");
                }

                double a = pile.Pop();
                double b = pile.Pop();
                double resultat = a * b;
                pile.Push(resultat);

                // Réponse de succès avec le résultat de la multiplication
                return Ok(resultat);
            }
        }

        // Endpoint pour effectuer l'opération de division
        [HttpPost("DIVISION")]
        public ActionResult<double> Division()
        {
            lock (pile)
            {
                if (pile.Count < 2)
                {
                    // Erreur : Pas assez d'éléments dans la pile pour effectuer la division
                    return BadRequest("Il n'y a pas assez d'éléments dans la pile pour effectuer la division.");
                }

                double a = pile.Pop();
                double b = pile.Pop();

                if (a == 0)
                {
                    // Erreur : Division par zéro impossible
                    return BadRequest("Division par zéro impossible.");
                }

                double resultat = b / a;
                pile.Push(resultat);

                // Réponse de succès avec le résultat de la division
                return Ok(resultat);
            }
        }
    }
}