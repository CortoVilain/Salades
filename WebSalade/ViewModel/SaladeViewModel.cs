using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CodeFirst2;
using System.Web.Mvc;

namespace WebSalade.ViewModel
{
    public class SaladeViewModel
    {
        public Salade Salade { get; set; }
        public IEnumerable<SelectListItem> AllComposant { get; set; }
        private List<int> _selectedComposant;
        public List<int> SelectedComposant
        {
            get
            {
                if(_selectedComposant == null)
                {
                    _selectedComposant = Salade.Composants.Select(s => s.ID).ToList();
                }
                return _selectedComposant;
            }
            set { _selectedComposant = value; }
        }
    }
}