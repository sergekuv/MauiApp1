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
	//	imgList.ItemsSource = photos.GetAllImages();

	}

	//List<string> GetPhotoImages() => Directory.GetFiles(ImgInfo.CameraFolder).ToList();

	private void OnDetailsButtonClicked(object sender, EventArgs e)
	{


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
                //for(int i = 0; i<Images.Count; i++)
                //{
                //    if (Images[i].Src == s)
                //    {
                //        Images.RemoveAt(i);
                //        selected = null;
                //        break;
                //    }
                //}
                Images.Remove(toRemove);
                //selected = null;

                File.Delete(fileToDelete);
                await DisplayAlert("Deleted", "File deleted: " + fileToDelete, "OK");
                //Images.Clear();
                Images = photos.GetAllImages();
            }
            catch (Exception ex)
            {
                await DisplayAlert("DeleteImage", "Error when deleting: " + ex.Message, "OK");
            }
        }
        
        //imgList.SetBinding(ItemsView.ItemsSourceProperty, "Images");
        //imgList.ItemsSource = photos.GetAllImages();
        //imgList.(selected);

    }

 //   private void imgList_ItemSelected(object sender, SelectedItemChangedEventArgs e)
	//{
	//	selected = (Image)e.SelectedItem;
 //       DisplayAlert("Выбор", $"Вы выбрали файл: {selected.Src.ToString().Substring(6)}", "OK");
 //   }

    private void imgList_ItemSelected(object sender, SelectionChangedEventArgs e)
    {
        selected = (Image)e.CurrentSelection[0];
        DisplayAlert("Выбор", $"Вы выбрали файл: {selected.Src.ToString().Substring(6)}", "OK");
    }
}