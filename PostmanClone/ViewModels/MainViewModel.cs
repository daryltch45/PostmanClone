using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Dynamic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using PostmanClone.Utilities;
using PostmanClone.Request;
using System.Windows;
using System.Net.Http;

namespace PostmanClone.ViewModels
{

  class MainViewModel : INotifyCollectionChanged, INotifyPropertyChanged
  {
    #region Properties 
    public event NotifyCollectionChangedEventHandler? CollectionChanged;
    public event PropertyChangedEventHandler? PropertyChanged;
    private string _requestUrl;

    private bool _isReadOnlyResponseText; 
    public bool IsReadOnlyResponseText 
    {
      get => _isReadOnlyResponseText;
      set
      {
        if (_isReadOnlyResponseText != value)
        {
          _isReadOnlyResponseText = value;
          OnPropertyChanged(nameof(IsReadOnlyResponseText)); 
        }
      }
    }
    public string RequestUrl
    {
      get => _requestUrl;
      set
      {
        if (_requestUrl != value)
        {
          _requestUrl = value;
          OnPropertyChanged(nameof(RequestUrl));
        }
      }
    }

    private string _selectedRequestType;
    public string SelectedRequestType
    {
      get => _selectedRequestType;
      set
      {
        if (_selectedRequestType != value)
        {
          _selectedRequestType = value;
          OnPropertyChanged(nameof(SelectedRequestType));
          if (_selectedRequestType == "GET")
          {
            IsReadOnlyResponseText = true;
            ResponseBody = ""; 
          }
          else
          {
            IsReadOnlyResponseText = false;
          }
        }
      }
    }
    private ObservableCollection<string> _requestTypes;
    public ObservableCollection<string> RequestTypes
    {
      get => _requestTypes;
      set
      {
        if (value != _requestTypes)
        {
          _requestTypes = value;
          OnPropertyChanged(nameof(RequestTypes));
        }
      }
    }
    //private string _selectedTab;
    //public string SelectedTab
    //{
    //  get => _selectedTab;
    //  set
    //  {
    //    if (_selectedTab != value)
    //    {
    //      _selectedTab = value;
    //      OnPropertyChanged(nameof(SelectedTab));
    //    }
    //  }
    //}

    private string _responseBody;
    public string ResponseBody
    {
      get => _responseBody;
      set
      {
        if (_responseBody != value)
        {
          _responseBody = value;
          OnPropertyChanged(nameof(ResponseBody));
        }
      }
    }

    private string _result;
    public string Result
    {
      get => _result;
      set
      {
        if (_result != value)
        {
          _result = value;
          OnPropertyChanged(nameof(Result));
        }
      }
    }


    private readonly IAPIaccess api;
    #endregion Properties


    #region Commands

    public ICommand CopyToClipboardCommand { get; }
    public ICommand SendRequestCommand
    {
      get;
    }
    #endregion Commands

    public MainViewModel()
    {
      api = new APIaccess();
      _requestTypes = new ObservableCollection<string>(
        Enum.GetNames(typeof(RequestType))
        );

      _selectedRequestType = RequestType.GET.ToString();
      _requestUrl = string.Empty;
      _isReadOnlyResponseText = true;
      _responseBody = string.Empty; 
      _result = string.Empty; 

      SendRequestCommand = new RelayCommand(
          async (_) =>
          {
            try
            {
              if (!api.IsValidUrl(_requestUrl))
                throw new Exception("Invalid URL...");
              
              StringContent data = new StringContent
              (
                _responseBody, 
                Encoding.UTF8, 
                "application/json"
                );

              Result = await api.makeRequest
              (
                _requestUrl,
                data,
              (RequestType)Enum.Parse(typeof(RequestType),_selectedRequestType)
              );
              //SelectedTab = "Result";
            }
            catch (Exception ex)
            {
              MessageBox.Show(ex.Message);
            }


          }

        );

      CopyToClipboardCommand = new RelayCommand(
        (_) =>
        {
          Clipboard.SetText(Result);
        });
    }


    #region Fonctions
    private void CreateCommands() { }



    protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
      PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
    #endregion Fonctions

  }
}