using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
	public class WriterValidator : AbstractValidator<Writer>
	{
		public WriterValidator()
		{
			RuleFor(x => x.WriteName).NotEmpty().WithMessage("Yazar adı boş geçilemez");

			RuleFor(x => x.WriterMail).NotEmpty().WithMessage("Yazar mail adresi kısmı boş geçilemez");

			RuleFor(x => x.WriterPassword).NotEmpty().WithMessage("Yazar şifresi boş geçilemez");

			RuleFor(x => x.WriteName).MinimumLength(2).WithMessage("Lütfen en az 2 karakter girişi yapınız");

			RuleFor(x => x.WriteName).MaximumLength(50).WithMessage("Lütfen en fazla 50 karakter girişi yapınız");
		}
	}
}
