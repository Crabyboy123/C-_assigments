using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace PV178.Homeworks.Homework1
{
    /// <summary>
    /// Souřadnice v herním světě.
    /// </summary>
    public interface ICoordinates
    {
        /// <summary>
        /// Souřadnice zleva.
        /// </summary>
        int Left { get; set; }

        /// <summary>
        /// Souřadnice shora.
        /// </summary>
        int Top { get; set; }


        /// <summary>
        /// Vrací true, pokud jsou tyto souřadnice uvnitř zadaného obdélníku.
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Výška nebo šířka obdélníku je nulová nebo záporná.
        /// </exception>
        /// <returns>
        ///     <c>true</c> pokud jsou souřadnice uvnitř zadaného obdélníku; jinak <c>false</c>.
        /// </returns>
        bool IsInRectangle(int left, int top, int width, int height);
    }
}