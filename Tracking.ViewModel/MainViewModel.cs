using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media.Media3D;
using Tracking.Model;

namespace Tracking.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        private MainModel _model;


        private List<Track> tracklist;
        private List<Track> tracklistdos;
        private bool isChecked;

        private bool _hasInstalled;


        public bool HasInstalled
        {
            get { return _hasInstalled; }
            private set
            {
                _hasInstalled = value;
                OnPropertyChanged("HasInstalled");
            }
        }

        private ICommand rightCommand;
        private ICommand leftCommand;
        private ICommand rightMulCommand;
        private ICommand leftMulCommand;
        private Track trackSelected;
        public Track TrackSelected
        {
            get
            {
                return trackSelected;
            }
            set
            {
                if (trackSelected == value) return;
                trackSelected= value;
                OnPropertyChanged("TrackSelected");
            }
        }
        private Track trackDosSelected;
        public Track TrackDosSelected
        {
            get
            {
                return trackDosSelected;
            }
            set
            {
                if (trackDosSelected == value) return;
                trackDosSelected = value;
                OnPropertyChanged("TrackDosSelected");
            }
        }

        public bool IsChecked
        {
            get
            {
                return isChecked;
            }
            set
            {
                if (isChecked == value) return;
                isChecked = value;
                OnPropertyChanged("IsChecked");
            }
        }
        public List<Track> TrackList
        {
            get { return tracklist; }
            set
            {
                if (tracklist == value) return;
                tracklist = value;
                OnPropertyChanged("TrackList");
            }
        }
        public List<Track> TrackListdos
        {
            get { return tracklistdos; }
            set
            {
                if (tracklistdos == value) return;
                tracklistdos = value;
                OnPropertyChanged("TrackListdos");
            }
        }


        public ICommand RightCommand
        {
                get
                {
                    if (rightCommand == null)
                    {
                        rightCommand = new RelayCommand(x => this.rightCommandExecute(), null);
                    }
                    return rightCommand;
                }
        }
        public ICommand LeftCommand
        {
            get
            {
                if (leftCommand == null)
                {
                    leftCommand = new RelayCommand(x => this.leftCommandExecute(), null);
                }
                return leftCommand;
            }
        }
        public ICommand RightMulCommand
        {
            get
            {
                if (rightMulCommand == null)
                {
                    rightMulCommand = new RelayCommand(x => this.rightMulCommandExecute(), null);
                }
                return rightMulCommand;
            }
        }
        public ICommand LeftMulCommand
        {
            get
            {
                if (leftMulCommand == null)
                {
                    leftMulCommand = new RelayCommand(x => this.leftMulCommandExecute(), null);
                }
                return leftMulCommand;
            }
        }
        public MainViewModel()
        {
            _model = new MainModel();
            TrackList= _model.GetLeftTracking();
            TrackListdos = _model.GetRigthTracking();
            HasInstalled = false;
        }

        private async void rightCommandExecute()
        {
            try
            {

                var task = new Task(() =>
                {
                    List<Track> left = new List<Track>();
                    List<Track> right = new List<Track>();
                    left.AddRange(tracklist);
                    right.AddRange(tracklistdos);

                Thread.Sleep(6000);

                    HasInstalled = false;

                    //Llamada a metodo sincrono
                    _model.Move(trackSelected, ref left, ref right, MoveType.LeftToRight);
                    //Llamada a metodo asincrono, ejemplo
                    //Results result = await _model.MoveAsync(trackSelected, left, right, MoveType.LeftToRight);


                    //var task = new Task(() => _model.Move(trackSelected, ref left, ref right, MoveType.LeftToRight));
                    //task.Start();

                    //Thread cantinero1 = new Thread(new ThreadStart(Cantinero1Atiende));
                    //Thread cantinero2 = new Thread(new ThreadStart(Cantinero2Atiende));
                    //cantinero1.Start();
                    //cantinero2.Start();

                    TrackList = null;
                    TrackListdos = null;

                    TrackList = left;
                    TrackListdos = right;
                });
       
                task.Start();
                HasInstalled = true;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Failed", MessageBoxButton.OK, MessageBoxImage.Error);
            }      

        }
        private void leftCommandExecute()
        {
            try {

                var task = new Task(() =>
                {
                List<Track> left = new List<Track>();
                List<Track> right = new List<Track>();
                left.AddRange(tracklist);
                right.AddRange(tracklistdos);

                Thread.Sleep(6000);
                    HasInstalled = false;
                    _model.Move(trackDosSelected, ref left, ref right, MoveType.RightToLeft);              

                TrackList = null;
                TrackListdos = null;

                TrackList = left;
                TrackListdos = right;

                });
                task.Start();
                HasInstalled = true;
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message, "Failed", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void rightMulCommandExecute()
        {
            try
            {
                var task = new Task(() =>
                {
                List<Track> left = new List<Track>();
                List<Track> right = new List<Track>();
                left.AddRange(tracklist);
                right.AddRange(tracklistdos);

                    Thread.Sleep(6000);
                    HasInstalled = false;
                    _model.MoveMultiple(ref left, ref right, MoveType.LeftToRight);                

                TrackList = null;
                TrackListdos = null;

                TrackList = left;
                TrackListdos = right;
            });

                task.Start();
                HasInstalled = true;
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Failed", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            

        }
        private void leftMulCommandExecute()
        {
            try
            {
                var task = new Task(() =>
                {
                List<Track> left = new List<Track>();
                List<Track> right = new List<Track>();
                left.AddRange(tracklist);
                right.AddRange(tracklistdos);

                    Thread.Sleep(6000);

                    HasInstalled = false;
                    _model.MoveMultiple(ref left, ref right, MoveType.RightToLeft);
                
                TrackList = null;
                TrackListdos = null;

                TrackList = left;
                TrackListdos = right;
                });

                task.Start();
                HasInstalled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Failed", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
