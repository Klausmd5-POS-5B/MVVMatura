using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using DB;
using MvvmTools;

namespace LernSiegWPF;

public class MainViewModel : ObservableObject
{
    public SiegContext _db;

    public MainViewModel(SiegContext db) => _db = db;
    
    public ObservableCollection<Teacher> Teachers
    {
        get => _db.Teachers.AsObservableCollection();
    }

    public Teacher SelectedTeacher
    {
        get => _selectedTeacher;
        set
        {
            _selectedTeacher = value;
            NotifyPropertyChanged(nameof(CurTeachSchool));
            NotifyPropertyChanged(nameof(SelScool));
        }
    }
    private Teacher _selectedTeacher;

    public string CurTeachSchool { get => Schools.First(x=>x.SchoolNumber == SelectedTeacher.SchoolId).Name + Schools.First(x=>x.SchoolNumber == SelectedTeacher.SchoolId).Address ?? "Ollie Dollie"; }
    public School SelScool { get => Schools.First(x=>x.SchoolNumber == SelectedTeacher.SchoolId); }
    
    public ObservableCollection<School> Schools
    {
        get => _db.Schools.AsObservableCollection();
    }
    
    public ICommand YeetDB => new RelayCommand<string>(x=>
    {
        _db.Database.EnsureDeleted();
        NotifyPropertyChanged(nameof(Teachers));
        NotifyPropertyChanged(nameof(Schools));
    });
    
    public ICommand FixDB => new RelayCommand<string>(x=>
    {
        _db.Database.EnsureCreated();
        NotifyPropertyChanged(nameof(Teachers));
        NotifyPropertyChanged(nameof(Schools));
    });
    
}