//using static Android.Media.Audiofx.DynamicsProcessing;


using Microsoft.Maui.Controls;
using System.Collections.ObjectModel;
//using static Android.Provider.MediaStore;
using System.Linq.Expressions;

namespace PhoneWord.Pages;

public partial class ImageList : ContentPage
{
	ImgInfo photos;
	Image selected;
    public ObservableCollection<Image> Images { get; set; } = new();
    public ImageList()
	{
		InitializeComponent();

		photos = new();
        Images = photos.GetAllImages();
        imgList.ItemsSource = Images;
	}


	private async void OnDetailsButtonClicked(object sender, EventArgs e)
	{
        if (selected == null)
        {
            await DisplayAlert("View Image", "Item is not selected", "OK");
        }
        else
        {
            var toRemove = selected as Image;
            var s = toRemove.Src;
            string fileToDelete = toRemove.Src.ToString().Substring(6);

            try
            {
                await Navigation.PushAsync(new ImageDetails(selected));
            }
            catch (Exception ex)
            {
                await DisplayAlert("VieweImage", "Error when opening image: " + ex.Message, "OK");
            }
        }
    }

    private async void OnDeleteButtonClicked(object sender, EventArgs e)
	{
        if (selected == null)
        {
            await DisplayAlert("DeleteImage", "Item is not selected", "OK");
        }
        else
        {
            var toRemove = selected as Image;
            var s = toRemove.Src;
            string fileToDelete = toRemove.Src.ToString().Substring(6);

            try
            {
                Images.Remove(toRemove);
                File.Delete(fileToDelete);
                await DisplayAlert("Deleted", "File deleted: " + fileToDelete, "OK");
               // Images = photos.GetAllImages();
            }
            catch (Exception ex)
            {
                await DisplayAlert("DeleteImage", "Error when deleting: " + ex.Message, "OK");
            }
        }
    }

    private void imgList_ItemSelected(object sender, SelectionChangedEventArgs e)
    {
        selected = (Image)e.CurrentSelection[0];
        //DisplayAlert("Выбор", $"Вы выбрали файл: {selected.Src.ToString().Substring(6)}", "OK");
    }
}