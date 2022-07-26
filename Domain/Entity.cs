using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain
{
	public abstract class Entity : object
	{
		public Entity() : base()
		{
			Id = Guid.NewGuid();
			InsertDateTime = DateTime.Now;
		}

		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.None)]
		public Guid Id { get; set; }

		public DateTime InsertDateTime { get; set; }
	}
}
