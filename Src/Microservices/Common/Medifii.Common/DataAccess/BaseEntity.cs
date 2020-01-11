using System;
using System.ComponentModel.DataAnnotations;

namespace Medifii.Common.DataAccess
{
	public abstract class BaseEntity
	{
		public BaseEntity()
		{
			Id = Guid.NewGuid();
			Created = DateTime.UtcNow;
		}

		[Key]
		public Guid Id { get; protected set; }

		public DateTime Created { get; protected set; }

		public DateTime Modified { get; protected set; }
	}
}
