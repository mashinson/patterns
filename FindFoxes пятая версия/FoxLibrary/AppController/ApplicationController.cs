using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace FindFoxes
{
   
    /// <summary>
    /// Simple implementation of the pattern Application Controller
    /// </summary>
    public class ApplicationController
    {

        public ApplicationController()
        {
            Commands = new SortedList<GameForms, BasePresenter>();
        }

        /// <summary>
        /// Show form
        /// </summary>
        /// <param name="form">game form</param>
        public void RunForm(GameForms form)
        {
            Commands[form].Run();
        }

        /// <summary>
        /// Add form and it presenter to the SortedList
        /// </summary>
        /// <param name="form">Game forms</param>
        /// <param name="presenter">which preseter has form</param>
        public void Add(GameForms form, BasePresenter presenter)
        {
            Commands.Add(form, presenter);
        }

        
        /// <summary>
        /// Dictionary of all forms and their presenters
        /// </summary>
        private IDictionary<GameForms, BasePresenter> Commands;
    }
}
