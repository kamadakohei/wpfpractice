using System.Collections.Generic;
using System.Linq;
using WpfApp10.Models;
using System.Collections.ObjectModel;

namespace WpfApp10.ViewModels
{
    internal class MainViewModel : NotificationObject
    {

        private ObservableCollection<Person> _people = new ObservableCollection<Person>();

       

        public ObservableCollection<Person> People
        {
            get { return this._people; }
            private set { SetProperty(ref this._people, value); }
        }

        private int _count;

        private DelegateCommand _addCommand;
        
        //追加
        public DelegateCommand AddCommand
        {
            get
            {
                return this._addCommand ?? (this._addCommand = new DelegateCommand(
                    _ =>
                    {
                        this._count++;
                        var person = new Person()
                        {
                            FamilyName = "田中",
                            FirstName = this._count + "太郎",
                            Age = this._count,
                        };
                        this.People.Add(person);
                        this.DeleteCommand.RaiseCanExecuteChanged();

                        System.Diagnostics.Debug.WriteLine(person.FullName + " を追加しました");
                    }));
            }
        }

        private DelegateCommand _deleteCommand;

        public DelegateCommand DeleteCommand
        {
            get
            {
                return this._deleteCommand ?? (this._deleteCommand = new DelegateCommand(
                _ =>
                {
                    this.People.RemoveAt(this.People.Count - 1);
                    this.DeleteCommand.RaiseCanExecuteChanged();

                    System.Diagnostics.Debug.WriteLine("削除しました。");
                },
                _ => this.People.Count > 0));
            }
        }
    }

}