using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PV178.Homeworks.Homework2.Entities
{
    /// <summary>
    /// Třída reprezentuje záznam v chybovém logu databázového serveru
    /// </summary>
    public class SQLServerLogEvent
    {
        /// <summary>
        /// Datum a čas, kdy došlo k vytvoření záznamu o chybě
        /// </summary>
        public DateTime EventTime { get; set; }

        /// <summary>
        /// Jméno serveru, kde došlo k chybě
        /// </summary>
        public string ServerName { get; set; }

        /// <summary>
        /// Číslo chyby, která byla zachycena
        /// </summary>
        public int ErrorNumber { get; set; }

        /// <summary>
        /// Závažnost chyby (v rozsahu 0-24)
        /// </summary>
        public int ErrorSeverity { get; set; }

        /// <summary>
        /// Pokud došlo k chybě v konkrétní databázi, je v chybovém logu uvedeno její jméno
        /// </summary>
        public string DatabaseName { get; set; }

        /// <summary>
        /// Původní textový popis chyby
        /// </summary>
        public string ErrorMessage { get; set; }
    }
}
