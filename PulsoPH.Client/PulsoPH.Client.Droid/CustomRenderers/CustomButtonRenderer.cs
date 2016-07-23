using Android.Graphics;
using Java.Lang;
using PulsoPH.Client.CustomRenderers;
using PulsoPH.Client.UserControls;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(CustomButton), typeof(CustomButtonRenderer))]
namespace PulsoPH.Client.CustomRenderers
{
	public class CustomButtonRenderer : ButtonRenderer
	{
		protected override void OnElementChanged(ElementChangedEventArgs<Button> e)
		{
			base.OnElementChanged(e);

			if (Control != null)
			{
				CustomButton model = (CustomButton)this.Element;

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