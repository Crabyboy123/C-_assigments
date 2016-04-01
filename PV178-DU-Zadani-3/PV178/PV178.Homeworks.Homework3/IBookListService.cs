using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PV178.Homeworks.Homework3
{
    public interface IBookListService
    {
        /// <summary>
        /// Vypíše kódy a názvy kurzů, jejichž kódy začínají zadaným řetězcem, bez ohledu na velikost písmen.
        /// </summary>
        /// <param name="startsWith">Řetězec, na který začínají kódy kurzů. Na velikosti písmen nezáleží.</param>
        /// <returns>Kolekce řetězců obsahující kód a název kurzu pro všechny kurzy začínající na text <paramref name="startsWith"/>.</returns>
        /// <exception cref="ArgumentNullException">Řetězec <paramref name="startsWith"/> nesmí být <c>null</c>.</exception>
        /// <remarks>Where, Select, ToList</remarks>
        IList<string> ListCoursesByFirstLetterOfCode(string startsWith);

        /// <summary>
        /// Vrátí všechny obory, které se vyskytující ve vstupních datech. U názvu oboru nezáleží na velikosti písmen.
        /// </summary>
        /// <remarks>rozšiřující metoda Distinct, třída StringComparer</remarks>
        IEnumerable<string> ListAreas();

        /// <summary>
        /// Vypíše seznam učitelů a počet předmětů, které daný učitel učí.
        /// </summary>
        /// <remarks>rozšiřující metody GroupBy, Count</remarks>
        IEnumerable<Tuple<string, int>> ListTeachers();

        /// <summary>Vrátí seznam kódu kurzů, které v seznamu nemají zadánu žádnou knihu.</summary>
        /// <returns>Kódy kurzů.</returns>
        /// <remarks>GroupBy, Where, Select, ToArray</remarks>
        string[] CoursesWithoutBook();

        /// <summary>
        /// Vrací informaci o tom, jestli každou knihu doporučenou pro zadaný obor lze koupit.
        /// </summary>
        /// <param name="area">Obor, pro který informaci zjišťujeme. Nezáleží na velikosti písmen.</param>
        /// <returns><c>true</c> pokud lze každou z knih koupit; <c>false</c> jinak.</returns>
        /// <remarks>All</remarks>
        bool  AreAllBooksBuyable(string area);

        /// <summary>
        /// Vrací <c>true</c>, pokud si lze alespoň jednu z knih pro zadaný obor vypůjčit.
        /// </summary>
        /// <param name="area">Obor, pro který informaci zjišťujeme. Nezáleží na velikosti písmen.</param>
        /// <returns><c>true</c> pokud lze každou z knih koupit; <c>false</c> jinak.</returns>
        /// <remarks>Any</remarks>
        bool IsAnyBookOfBookRentable(string area);

        /// <summary>
        /// Vrací počet knih, které lze vypůjčit.
        /// </summary>
        /// <remarks>Count(r => r...)</remarks>
        int CountRentableBooks();

        /// <summary>
        /// Spočítá a vrátí průměrnou cenu za novou knihu (pro všechny knihy, které lze zakoupit jako nové) aritmeticky zaokrouhlenou na celou část.
        /// </summary>
        /// <remarks>Where, Average, Math.Round</remarks>
        int GetRoundedAveragePriceOfNewBook();

        /// <summary>
        /// Vrátí titul první knihy určené pro předmět zadaného kódu.
        /// </summary>
        /// <param name="courseCode">Kód kurzu. Na velikosti písmen nezáleží.</param>
        /// <returns>Název knihy nebo <c>null</c>, pokud pro kurz není kniha zadána.</returns>
        /// <exception cref="ArgumentNullException">Řetězec <paramref name="courseCode"/> nesmí být <c>null</c>.</exception>
        /// /// <exception cref="ArgumentException">Řetězec <paramref name="courseCode"/> nesmí být prázdný řetězec nebo obsahovat prázdné znaky.</exception>
        string GetFirstBookForCourse(string courseCode);

        /// <summary>
        /// Vypíše pro všechny předměty kolekci dvojice kód předmětu - obor předmětu. Jeden předmět vždy patří do jednoho oboru a jeden předmět se nesmí vyskytnout dvakrát.
        /// </summary>
        /// <returns>Kolekce dvojic (kód předmětu - obor předmětu).</returns>
        IEnumerable<Tuple<string, string>> ListAllCoursesWithArea();

        /// <summary>
        /// Vypíše pro všechny předměty kolekci dvojice kód předmětu - obor předmětu. Jeden předmět vždy patří do jednoho oboru a jeden předmět se nesmí vyskytnout dvakrát.
        /// Použijte rozšiřující metodu ToDictionary.
        /// </summary>
        /// <returns>Kolekce dvojic (kód předmětu - obor předmětu).</returns>
        /// <remarks>ToDictionary</remarks>
        IDictionary<string, string> ListAllCoursesWithAreaAsDictionary();

        /// <summary>
        /// Vrátí seznam všech učitelů a jimi vyučovaných kurzů, u kterých není uvedena kniha.
        /// </summary>
        IEnumerable<Tuple<string, IEnumerable<string>>> ListTeachersAndCoursesWithoutBook();

        /// <summary>Vrátí počet knih pro každý z kurzů uvedený v parametru <paramref name="codes"/>. Implementujte s použitím join.</summary>
        /// <param name="codes">Kódy kurzů. . Na velikosti písmen nezáleží.</param>
        /// <returns>Kolekce dvojic kód kurzu-počet knih kurzu.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="codes"/> nesmí být <c>null</c>.</exception>
        /// <exception cref="ArgumentException"><paramref name="codes"/> nesmí obsahovat prvek <c>null</c>.</exception>
        /// <remarks>Implementujte s použitím Join.</remarks>
        IEnumerable<Tuple<string, int>> ListBookCountPerCourseUsingJoin(params string[] codes);

        /// <summary>
        /// Vrátí kód kurzu (nebo kurzů), který má nejdražší novou knihu.
        /// </summary>
        /// <returns></returns>
        /// <remarks>Where, Max, Select</remarks>
        IEnumerable<string> ListCoursesWithMostExpensiveBook();

        /// <summary>Vrátí názvy 3 nejdražších knih ke koupi napříč zadanými oblastmi.</summary>
        /// <param name="areas">Seznam oborů, pro které probíhá hledání. Knihy z oborů, které nejsou uvedeny se z hledání vynechají. Na velikosti písmen nezáleží.</param>
        /// <returns>Nejvýše tři knihy, které jsou nejdražší.</returns>
        /// <remarks>OrderByDescending, Take</remarks>
        /// <exception cref="ArgumentNullException"><paramref name="areas"/> nesmí být <c>null</c>.</exception>
        /// <exception cref="ArgumentException"><paramref name="areas"/> nesmí obsahovat prvek <c>null</c>.</exception>
        IEnumerable<string> ListThreeMostExpensiveBooks(IEnumerable<string> areas);
    }
}
