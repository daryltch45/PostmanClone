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
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows;

namespace PostmanClone.ViewModels
{
  enum RequestType { GET, POST, SET, PUT }
  class MainViewModel : INotifyCollectionChanged, INotifyPropertyChanged
  {
    #region Properties 
    public event NotifyCollectionChangedEventHandler? CollectionChanged;
    public event PropertyChangedEventHandler? PropertyChanged;
    private string _requestUrl;
    public string RequestUrl
    {
      get => _requestUrl;
      set
      {
        if (_requestUrl != value)
        {
          _requestUrl = value;
          OnPropertyChanged(nameof(RequestUrl));
          CommandManager.InvalidateRequerySuggested();
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
    public HttpClient httpClient { get; set; }

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
    #endregion Properties


    #region Commands

    public ICommand CopyToClipboardCommand { get;  }
    public ICommand SendRequestCommand
    {
      get;
    }
    #endregion Commands

    public MainViewModel()
    {
      _requestTypes = new ObservableCollection<string>(
        Enum.GetNames(typeof(RequestType))
        );

      _selectedRequestType = RequestType.GET.ToString();

      httpClient = new HttpClient();

      SendRequestCommand = new RelayCommand(
          async (e) =>
          {

            if (!string.IsNullOrEmpty(_requestUrl))
            {
              try
              {
                ResponseBody = await getRequest(_requestUrl);
                //getRequest(_requestUrl);
              }
              catch (Exception ex)
              {
                MessageBox.Show(ex.Message);
              }
            }
            else
            {
              MessageBox.Show("URL is empty !");
            }

          }

        );

      CopyToClipboardCommand = new RelayCommand(
        (e) =>
        {
          Clipboard.SetText(_responseBody);
        });
    }


    #region Fonctions
    private void CreateCommands() { }
    private async Task<string> getRequest(string url)
    {
      try
      {
        HttpResponseMessage response = await httpClient.GetAsync(url);

        string responseData = await response.Content.ReadAsStringAsync();

        return responseData;
      }
      catch (HttpRequestException e)
      {
        return "Request Error";
      }

    }


    protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
      PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
    #endregion Fonctions

  }
}