using System.Collections.Specialized;
using System.Globalization;
using System.Web.Mvc;

namespace EnduranceGoals.Models
{
    public class  ModelValidator : Controller
    {
        public new  ModelStateDictionary ValidateModel(object model)
        {
            var metadataForType = ModelMetadataProviders.Current.GetMetadataForType(() => model, model.GetType());
            var modelBinder = new ModelBindingContext()
                                  {
                                      ModelMetadata =
                                          metadataForType,
                                      ValueProvider =
                                          new NameValueCollectionValueProvider(new NameValueCollection(),
                                                                               CultureInfo.InvariantCulture)
                                  };
            var binder = new DefaultModelBinder().BindModel(new ControllerContext(), modelBinder);
            this.ModelState.Clear();
            this.ModelState.Merge(modelBinder.ModelState);
            return this.ModelState;
        }
    }
}