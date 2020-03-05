

namespace FindFoxes
{   
    /// <summary>
    /// It used for showing forms that don't have their own presenters
    /// </summary>
    public class CommonPresenter: BasePresenter
    {      
        public CommonPresenter(CommonFormInterface form)
        {
            _form = form;
        }

        public void Run()
        {
            _form.Show();
        }

        private CommonFormInterface _form;

       
    }
}
