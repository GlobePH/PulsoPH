using Android.Graphics;
using Java.Lang;
using PulsoPH.Client.CustomRenderers;
using PulsoPH.Client.UserControls;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(CustomEntry), typeof(CustomEntryRenderer))]
namespace PulsoPH.Client.CustomRenderers
{
	public class CustomEntryRenderer : EntryRenderer
	{
		protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
		{
			base.OnElementChanged(e);

			if (Control != null)
			{
				CustomEntry model = (CustomEntry)this.Element;
				//int[][] states = {
				//	new int[] { Android.Resource.Attribute.StateEnabled}, // enabled
				//                new int[] {Android.Resource.Attribute.StateEnabled}, // disabled
				//                new int[] {Android.Resource.Attribute.StateChecked}, // unchecked
				//                new int[] { Android.Resource.Attribute.StatePressed}  // pressed
				//            };
				//var hintTextColor = (int)model.HintTextColor.ToAndroid();
				//int[] colors = {
				//	hintTextColor,
				//	hintTextColor,
				//	hintTextColor,
				//	hintTextColor
				//};

				//var myList = new Android.Content.Res.ColorStateList(states, colors);
				Control.SetHintTextColor(new Android.Graphics.Color(model.HintTextColor.ToAndroid()));

				if (!string.IsNullOrEmpty(model.FontFamilyName))
				{
					string fontFilename = "fonts" + model.FontFamilyName + ".ttf";
					try
					{
						Typeface font = Typeface.CreateFromAsset(Forms.Context.Assets, "fonts/" + model.FontFamilyName + ".ttf");  // font name specified here
						Control.Typeface = font;
					}
					catch
					{

					}
				}
			}
		}
	}
}