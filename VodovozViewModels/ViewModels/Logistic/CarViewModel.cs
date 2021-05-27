using QS.DomainModel.UoW;
using QS.Project.Domain;
using QS.Services;
using QS.ViewModels;
using Vodovoz.Domain.Logistic;
using Vodovoz.EntityRepositories.Logistic;

namespace Vodovoz.ViewModels.ViewModels.Logistic
{
	public class CarViewModel : EntityTabViewModelBase<Car>
	{
		private readonly ICarRepository _carRepository;

		public CarViewModel(
			IEntityUoWBuilder uowBuilder,
			IUnitOfWorkFactory unitOfWorkFactory,
			ICommonServices commonServices,
			ICarRepository carRepository)
			: base(uowBuilder, unitOfWorkFactory, commonServices)
		{
			_carRepository = carRepository;
		}

		public bool CanChangeVolumeWeightConsumption => CommonServices.PermissionService
			.ValidateUserPresetPermission("can_change_cars_volume_weight_consumption", CurrentUser.Id)
			|| Entity.Id == 0 
			|| !(Entity.IsCompanyCar || Entity.IsRaskat);

		public bool CanChangeBottlesFromAddress => CommonServices.PermissionService
			.ValidateUserPresetPermission("can_change_cars_bottles_from_address", CurrentUser.Id);

		public bool IsRaskatSensitive => CarTypeIsEditable
			|| CommonServices.CurrentPermissionService.ValidatePresetPermission("can_change_car_is_raskat");

		public bool TypeOfUseSensitive => CarTypeIsEditable;

		public bool CarTypeIsEditable => Entity.Id == 0;

		public bool MinBottlesFromAddressSensitive => CanChangeBottlesFromAddress;
		public bool MaxBottlesFromAddressSensitive => CanChangeBottlesFromAddress;

	}
}
