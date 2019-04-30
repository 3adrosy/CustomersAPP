using DAL.CustomAttributes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class BaseEntity : IBaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode  = false)]
        [Display(Name = "Created On")]
        [JsonConverter(typeof(DateFormatConverter))]
        public DateTime CreationDate { get; set; }
        public bool IsDeleted { get; set; }

        public BaseEntity()
        {
            CreationDate = DateTime.Now.Date;
        }
    }
}
