using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ViewaAPIProject.Models
{
    public class ViewaSample
    {
        [Key]
        public int Id { get; set; }
        public string CampaignName { get; set; }
        public string EventType { get; set; }
        public int AppUserId { get; set; }
        public string AppUserGender { get; set; }
        public DateTime EventDate { get; set; }
        public string AppDeviceType { get; set; }
    }
}
