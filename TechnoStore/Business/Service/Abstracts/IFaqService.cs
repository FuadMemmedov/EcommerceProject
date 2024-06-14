using Business.DTOs.FaqDTOs;
using Business.DTOs.FaqDTOs;
using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Service.Abstracts;

public interface IFaqService
{
    Task AddFaqAsync(FaqCreateDTO faqCreateDTO);
    void DeleteFaq(int id);
	void SoftDelete(int id);
	void UpdateFaq(FaqUpdateDTO updateDTO);
    FaqGetDTO GetFaq(Func<Faq, bool>? func = null, params string[]? includes);
    List<FaqGetDTO> GetAllFaqs(Func<Faq, bool>? func = null, params string[]? includes);
}
