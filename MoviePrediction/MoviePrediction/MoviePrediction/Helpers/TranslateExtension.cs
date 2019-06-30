using Plugin.Multilingual;
using System;
using System.Reflection;
using System.Resources;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MoviePrediction.Helpers
{
	[ContentProperty("Text")]
	public class TranslateExtension : IMarkupExtension
	{
		static readonly Lazy<ResourceManager> resourceManager = new Lazy<ResourceManager>(() => new ResourceManager(ApplicationProperties.ResourceId, typeof(TranslateExtension).GetTypeInfo().Assembly));

		public string Text { get; set; }

		public object ProvideValue(IServiceProvider serviceProvider)
		{
			if (Text == null)
				return String.Empty;

			var ci = CrossMultilingual.Current.CurrentCultureInfo;

			var translation = resourceManager.Value.GetString(Text, ci) ?? String.Empty;

			return translation;
		}
	}
}
