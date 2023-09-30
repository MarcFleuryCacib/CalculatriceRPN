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


        // Endpoint pour effectuer l'op�ration d'addition
        [HttpPost("ADD")]
        public ActionResult<double> Addition()
        {
            lock (pile)
            {
                if (pile.Count < 2)
                {
                    // Erreur : Pas assez d'�l�ments dans la pile pour effectuer l'addition
                    return BadRequest("Il n'y a pas assez d'�l�ments dans la pile pour effectuer l'addition.");
                }

                double a = pile.Pop();
                double b = pile.Pop();
                double resultat = a + b;
                pile.Push(resultat);

                // R�ponse de succ�s avec le r�sultat de l'addition
                return Ok(resultat);
            }
        }

        // Endpoint pour effectuer l'op�ration de soustraction
        [HttpPost("SUBTRACTION")]
        public ActionResult<double> Soustraction()
        {
            lock (pile)
            {
                if (pile.Count < 2)
                {
                    // Erreur : Pas assez d'�l�ments dans la pile pour effectuer la soustraction
                    return BadRequest("Il n'y a pas assez d'�l�ments dans la pile pour effectuer la soustraction.");
                }

                double a = pile.Pop();
                double b = pile.Pop();
                double resultat = b - a;
                pile.Push(resultat);

                // R�ponse de succ�s avec le r�sultat de la soustraction
                return Ok(resultat);
            }
        }

        // Endpoint pour effectuer l'op�ration de multiplication
        [HttpPost("MULTIPLICATION")]
        public ActionResult<double> Multiplication()
        {
            lock (pile)
            {
                if (pile.Count < 2)
                {
                    // Erreur : Pas assez d'�l�ments dans la pile pour effectuer la multiplication
                    return BadRequest("Il n'y a pas assez d'�l�ments dans la pile pour effectuer la multiplication.");
                }

                double a = pile.Pop();
                double b = pile.Pop();
                double resultat = a * b;
                pile.Push(resultat);

                // R�ponse de succ�s avec le r�sultat de la multiplication
                return Ok(resultat);
            }
        }

        // Endpoint pour effectuer l'op�ration de division
        [HttpPost("DIVISION")]
        public ActionResult<double> Division()
        {
            lock (pile)
            {
                if (pile.Count < 2)
                {
                    // Erreur : Pas assez d'�l�ments dans la pile pour effectuer la division
                    return BadRequest("Il n'y a pas assez d'�l�ments dans la pile pour effectuer la division.");
                }

                double a = pile.Pop();
                double b = pile.Pop();

                if (a == 0)
                {
                    // Erreur : Division par z�ro impossible
                    return BadRequest("Division par z�ro impossible.");
                }

                double resultat = b / a;
                pile.Push(resultat);

                // R�ponse de succ�s avec le r�sultat de la division
                return Ok(resultat);
            }
        }
    }
}