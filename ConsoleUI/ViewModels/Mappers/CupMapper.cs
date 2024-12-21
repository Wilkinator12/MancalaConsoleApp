using ConsoleLibrary.Common.Models;
using ConsoleUI.Models;
using MancalaLibrary.Models;

namespace ConsoleUI.ViewModels.Mappers
{
    public static class CupMapper
    {
        public static CupViewModel ToViewModel(this CupModel model)
        {
            var output = new CupViewModel()
            {
                IsHighlighted = model.IsActive,
                CupType = model.CupType,
                SeedCount = new DynamicText(model.SeedCount.ToString())
            };

            return output;
        }

        public static List<CupViewModel> ToViewModel(this List<CupModel> models)
        {
            var output = new List<CupViewModel>();


            foreach (var model in models)
            {
                var viewModel = model.ToViewModel();

                output.Add(viewModel);
            }

            return output;
        }

        public static CupModel ToModel(this CupViewModel viewModel)
        {
            var output = new CupModel()
            {
                IsActive = viewModel.IsHighlighted,
                CupType = viewModel.CupType,
                SeedCount = int.Parse(viewModel.SeedCount.ToString())
            };

            return output;
        }

        public static List<CupModel> ToModel(this List<CupViewModel> viewModels)
        {
            var output = new List<CupModel>();

            foreach (var viewModel in viewModels)
            {
                var model = viewModel.ToModel();

                output.Add(model);
            }

            return output;
        }
    }
}
