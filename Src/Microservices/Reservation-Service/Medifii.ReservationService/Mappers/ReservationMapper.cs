using Medifii.ReservationService.Dtos;
using Medifii.ReservationService.Entities;

namespace Medifii.ReservationService.Mappers
{
	public static class ReservationMapper
	{
		public static Reservation ToEntity(this ReservationDto dto)
		{
			return new Reservation
			{
				UserId = dto.UserId,
				ProductId = dto.ProductId,
				PharmacyId = dto.PharmacyId,
				Quantity = dto.Quantity,
				PickupTime = dto.PickupTime,
				Status = dto.Status
			};
		}

		public static ReservationDto ToDto(this Reservation entity)
		{
			return new ReservationDto
			{
				Id = entity.Id,
				UserId = entity.UserId,
				ProductId = entity.ProductId,
				PharmacyId = entity.PharmacyId,
				Quantity = entity.Quantity,
				PickupTime = entity.PickupTime,
				Status = entity.Status
			};
		}
	}
}
