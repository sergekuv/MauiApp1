//using static Android.Media.Audiofx.DynamicsProcessing;


using Microsoft.Maui.Controls;
using System.Collections.ObjectModel;
//using static Android.Provider.MediaStore;

namespace PhoneWord.Pages;

public partial class ImageList : ContentPage
{
	ImgInfo photos;
	Image selected;
    ObservableCollection<Image> Images { get; set; }
    public ImageList()
	{
		InitializeComponent();

		photos = new();
		imgList.ItemsSource = photos.GetAllImages();

	}

	//List<string> GetPhotoImages() => Directory.GetFiles(ImgInfo.CameraFolder).ToList();

	private void OnDetailsButtonClicked(object sender, EventArgs e)
	{


    }

    private void OnDeleteButtonClicked(object sender, EventArgs e)
	{
        if (selected == null)
        {
            DisplayAlert("DeleteImage", "Item is not selected", "OK");
        }
        else
        {
            try
            {
                File.Delete(selected.Src.ToString().Substring(6));
                DisplayAlert("Deleted", "File deleted: " + selected.Src.ToString().Substring(6), "OK");
            }
            catch (Exception ex)
            {
                DisplayAlert("DeleteImage", "Error when deleting: " + ex.Message, "OK");
            }
        }
        //imgList.ItemsSource = photos.GetAllImages();
        //imgList.(selected);
        
    }

    private void imgList_ItemSelected(object sender, SelectedItemChangedEventArgs e)
	{
		selected = (Image)e.SelectedItem;
        //DisplayAlert("Выбор", $"Вы выбрали файл: {selected.Src.ToString().Substring(6)}", "OK");
    }
}