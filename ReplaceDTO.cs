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

        public bool IsValid {
            get 
            {
                return (!string.IsNullOrEmpty(PuvodniTB) && !string.IsNullOrEmpty(PuvodniText) && !string.IsNullOrEmpty(NovyText));
            } 
        }
        public int PocetZmen
        {
            get
            {
                return (Regex.Matches(PuvodniTB, Regex.Escape(PuvodniText)).Count);
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
            string tmp = PuvodniText;
            PuvodniText = NovyText;
            NovyText = tmp;
        }

        public void ReplaceNovyTB()
        {
            if (PocatecniIndex > 0)
            {
                NovyTB = PuvodniTB.Replace(PuvodniText, NovyText+ (PocatecniIndex+1));
                PocatecniIndex++;
            }
            else
            {
                NovyTB = PuvodniTB.Replace(PuvodniText, NovyText);
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

        private string _puvodniText;

        public string PuvodniText
        {
            get
            {
                return _puvodniText;
            }
            set
            {
                if (_puvodniText != value)
                {
                    _puvodniText = value;
                    OnPropertyRaised("PuvodniText");
                    OnPropertyRaised("IsValid");
                    OnPropertyRaised("PocetZmen");
                }
            }
        }

        private string _novyText;

        public string NovyText
        {
            get
            {
                return _novyText;
            }
            set
            {
                if (_novyText != value)
                {
                    _novyText = value;
                    OnPropertyRaised("NovyText");
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
