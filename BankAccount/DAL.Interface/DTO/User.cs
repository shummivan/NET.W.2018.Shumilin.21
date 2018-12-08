using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Interface.DTO
{
    [Table("Table")]
    /// <summary>
    /// Simple bank account class
    /// </summary>
    public class User
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        /// <summary>
        /// Account number
        /// </summary>
        public int U_ID { get; set; }

        /// <summary>
        /// First name
        /// </summary>
        public string U_NAME { get; set; }

        /// <summary>
        /// Last name
        /// </summary>
        public string U_SURNAME { get; set; }

        /// <summary>
        /// Amount
        /// </summary>
        public decimal CASH { get; set; }

        /// <summary>
        /// Bonus points
        /// </summary>
        public decimal BONUS_POINTS { get; set; }

        /// <summary>
        /// Accont type
        /// </summary>
        public string A_TYPE { get; set; }

        /// <summary>
        /// Account status
        /// </summary>
        public string A_STATUS { get; set; }

        /// <summary>
        /// Enum type
        /// </summary>
        public enum AccountTypeGradation
        {
            Base,
            Gold,
            Platinum
        }

        /// <summary>
        /// Enum status
        /// </summary>
        public enum AccountStatus
        {
            Active,
            Closed
        }
    }
}
