using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hydac.Models
{
   public class IdeaPost
    {
        public int IdeaPostId { get; }
        public string IPTitle { get; set; }
        public string IPDescription { get; set; }
        public DateTime IPDOC {  get; set; }

        //Constructor fra vores DCD
        //public IdeaPost(string iPTitle, string iPDescription, DateTime pDOC)
        //{
        //    IPTitle = iPTitle;
        //    IPDescription = iPDescription;
        //    PDOC = pDOC;
        //}

        //Constructor taget ud fra PetParadise
        public IdeaPost(int ideaPostId)
        {
            IdeaPostId = ideaPostId;
        }
    }
}
