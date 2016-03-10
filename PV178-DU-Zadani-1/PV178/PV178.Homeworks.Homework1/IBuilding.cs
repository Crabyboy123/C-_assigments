using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PV178.Homeworks.Homework1
{
    /// <summary>
    /// Rozhraní reprezentující budovu.
    /// </summary>
    public interface IBuilding
    {
        /// <summary>
        /// Název stavební firmy.
        /// </summary>
        string ConstructionCompanyName { get; }

        /// <summary>
        /// Svět ve které je budovat postavena. Tuto vlastnost lze nastavit pouze jednou, poté už ji nelze změnit (pokus
        /// takto učinit nechť má za následek vyhození výjimky InvalidOperationException).
        /// </summary>
        /// <exception cref="InvalidOperationException">Došlo k pokusu o změnu jednou nastaveného světa.</exception>
        /// <exception cref="ArgumentNullException">Svět nesmí být nastaven na <c>null</c>.</exception>
        IWorld World { get; set; }


        /// <summary>
        /// Vypočte pozemkovou daň.
        /// </summary>
        /// <returns>Pozemková daň za budovu v FI$.</returns>
        /// <exception cref="InvalidOperationException">Pokud budova není zasazena do žádného světa.</exception>
        decimal CalculateLandTax();
    }
}
