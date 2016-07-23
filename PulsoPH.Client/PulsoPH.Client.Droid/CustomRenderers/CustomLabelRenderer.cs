using Android.Graphics;
using Android.Widget;
using Java.Lang;
using PulsoPH.Client.CustomRenderers;
using PulsoPH.Client.UserControls;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(CustomLabel), typeof(CustomLabelRenderer))]
namespace PulsoPH.Client.CustomRenderers
{
	public class CustomLabelRenderer : LabelRenderer
	{
		protected override void OnElementChanged(ElementChangedEventArgs<Label> e)
		{
			base.OnElementChanged(e);
			var label = (TextView)Control; // for example
			CustomLabel model = (CustomLabel)this.Element;
			if (!string.IsNullOrEmpty(model.FontFamilyName))
			{
				string fontFilename = "fonts" + model.FontFamilyName + ".ttf";
				try
				{
					Typeface font = Typeface.CreateFromAsset(Forms.Context.Assets, "fonts/" + model.FontFamilyName + ".ttf");  // font name specified here
					label.Typeface = font;
				}
				catch (Exception ex)
				{

				}
			}

		}
	}
}