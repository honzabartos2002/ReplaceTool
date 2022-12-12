using System.ComponentModel;
using System.Text.RegularExpressions;
using System.Windows.Markup;

namespace ReplaceTool
{
    public class ReplaceDTO: INotifyPropertyChanged
    {
        public ReplaceDTO() 
        {

        }

        public bool IsValid 
        {
            get 
            {
                return (!string.IsNullOrEmpty(PuvodniTB) && !string.IsNullOrEmpty(PuvodniExpression) && !string.IsNullOrEmpty(NovyExpression));
            } 
        }
        public int PocetZmen
        {
            get
            {
                return (Regex.Matches(PuvodniTB, Regex.Escape(PuvodniExpression)).Count);
            }
        }
        public void SwitchTBs()
        {
            string tmp = PuvodniTB;
            PuvodniTB = NovyTB;
            NovyTB= tmp;
        }
        public void SwitchExpressions()
        {
            string tmp = PuvodniExpression;
            PuvodniExpression = NovyExpression;
            NovyExpression = tmp;
        }

        public void ReplaceNovyTB()
        {
            if (PocatecniIndex > 0)
            {
                NovyTB = PuvodniTB.Replace(PuvodniExpression, NovyExpression + (PocatecniIndex + 1));
                PocatecniIndex++;
            }
            else
            {
                NovyTB = PuvodniTB.Replace(PuvodniExpression, NovyExpression);
            }
        }

        private void OnPropertyRaised(string propertyname)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyname));
            }
        }

        private int _prechoziPocetZmen;

        public int PrechoziPocetZmen
        {
            get
            {
                return _prechoziPocetZmen;
            }
            set
            {
                if (_prechoziPocetZmen != value)
                {
                    _prechoziPocetZmen = value;
                    OnPropertyRaised("PrechoziPocetZmen");
                }
            }
        }

        private int _pocatecniIndex = 0;

        public int PocatecniIndex
        {
            get
            {
                return _pocatecniIndex;
            }
            set
            {
                if (_pocatecniIndex != value)
                {
                    _pocatecniIndex = value;
                    OnPropertyRaised("PocatecniIndex");
                }
            }
        }
        private string _puvodniTB;

        public string PuvodniTB
        {
            get
            {
                return _puvodniTB;
            }
            set
            {
                if (_puvodniTB != value)
                {
                    _puvodniTB = value;
                    OnPropertyRaised("PuvodniTB");
                    OnPropertyRaised("IsValid");
                    OnPropertyRaised("PocetZmen");
                }
            }
        }

        private string _novyTB;

        public string NovyTB
        {
            get
            {
                return _novyTB;
            }
            set
            {
                if (_novyTB != value)
                {
                    _novyTB = value;
                    OnPropertyRaised("NovyTB");
                }
            }
        }

        private string _puvodniExpression;

        public string PuvodniExpression
        {
            get
            {
                return _puvodniExpression;
            }
            set
            {
                if (_puvodniExpression != value)
                {
                    _puvodniExpression = value;
                    OnPropertyRaised("PuvodniExpression");
                    OnPropertyRaised("IsValid");
                    OnPropertyRaised("PocetZmen");
                }
            }
        }

        private string _novyExpression;

        public string NovyExpression
        {
            get
            {
                return _novyExpression;
            }
            set
            {
                if (_novyExpression != value)
                {
                    _novyExpression = value;
                    OnPropertyRaised("NovyExpression");
                    OnPropertyRaised("IsValid");
                }
            }
        }

        private bool _copyText = true;

        public bool CopyText
        {
            get
            {
                return _copyText;
            }
            set
            {
                if (_copyText != value)
                {
                    _copyText = value;
                    OnPropertyRaised("CopyText");
                }
            }
        }

        private bool _replaceText;

        public bool ReplaceText
        {
            get
            {
                return _replaceText;
            }
            set
            {
                if (_replaceText != value)
                {
                    _replaceText = value;
                    OnPropertyRaised("ReplaceText");
                }
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;
    }
}
