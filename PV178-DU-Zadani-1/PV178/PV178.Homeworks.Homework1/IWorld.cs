using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace PV178.Homeworks.Homework1
{
    /// <summary>
    /// Rozhraní reprezentující herní svět.
    /// </summary>
    /// <remarks>
    /// Herní svět má neměnný počet políček na šířku a na výšku. Horní políčko má souřadnice [0,0], kladná poloosa X
    /// směřuje zleva doprava, kladná poloosa Y směřuje shora dolů.
    /// </remarks>
    public interface IWorld
    {
        /// <summary>
        /// Vrací šířku světa v počtu políček.
        /// </summary>
        int Width { get; }

        /// <summary>
        /// Vrací výšku světa v počtu políček.
        /// </summary>
        int Height { get; }

        /// <summary>
        /// Vrací počet políček, na kterých nestojí budovat.
        /// </summary>
        int FreeTiles { get; }


        /// <summary>
        /// Vrací souřadnice budovy ve světě.
        /// </summary>
        /// <param name="building">Hledaná budovat.</param>
        /// <exception cref="InvalidOperationException">Budova není ve městě.</exception>
        /// <exception cref="ArgumentNullException">
        /// Budova je <c>null</c> .
        /// </exception>
        /// <returns>
        /// Souřadnice budovy.
        /// </returns>
        ICoordinates GetBuildingLocation(IBuilding building);


        /// <summary>
        /// Zjistí budovu na daných souřadnicích.
        /// </summary>
        /// <param name="coordinates">Souřadnice políčka.</param>
        /// <returns>
        /// Vrací budovu, která stojí na zadaných souřadnicích, nebo <c>null</c> pokud je políčko prázdné.
        /// </returns>
        /// <exception cref="ArgumentOutOfRangeException">Souřadnice jsou mimo rozměry města.</exception>
        IBuilding GetBuildingAt(ICoordinates coordinates);


        /// <summary>
        /// Postaví budovu <paramref name="building" /> na souřadnice <paramref name="location" />.
        /// </summary>
        /// <param name="coordinates">Souřadnice políčka, které bude budova postavena.</param>
        /// <param name="building">Budova</param>
        /// <exception cref="InvalidOperationException">Budova je již postavena jinde nebo je políčko obsazeno.</exception>
        /// <exception cref="ArgumentNullException">Budova je null.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Souřadnice jsou mimo rozměry města.</exception>
        void Build(ICoordinates coordinates, IBuilding building);


        /// <summary>
        /// Vypočte celkovou pozemkovou daň ze všech budov.
        /// </summary>
        /// <returns>Celková daň ve FI$.</returns>
        decimal CalculateLandTax();
    }
}