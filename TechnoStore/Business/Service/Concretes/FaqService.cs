using AutoMapper;
using Business.DTOs.FaqDTOs;
using Business.Exceptions;
using Business.Service.Abstracts;
using Core.Models;
using Core.RepositoryAbstracts;
using Data.RepositoryConcretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Service.Concretes;

public class FaqService : IFaqService
{
    private readonly IFaqRepository _faqRepository;
    private readonly IMapper _mapper;

    public FaqService(IFaqRepository faqRepository, IMapper mapper)
    {
        _faqRepository = faqRepository;
        _mapper = mapper;
    }

    public async Task AddFaqAsync(FaqCreateDTO faqCreateDTO)
    {
        Faq faq = _mapper.Map<Faq>(faqCreateDTO);

       await _faqRepository.AddEntityAsync(faq);
       await _faqRepository.CommitAsync();
    }

    public void DeleteFaq(int id)
    {
        var existFaq = _faqRepository.GetEntity(x => x.Id == id);
        if (existFaq == null) throw new EntityNotFoundException("Faq tapilmadi");

        _faqRepository.DeleteEntity(existFaq);
        _faqRepository.Commit();
    }

    public List<FaqGetDTO> GetAllFaqs(Func<Faq, bool>? func = null, params string[]? includes)
    {
        var faqs = _faqRepository.GetAllEntities(func);
        List<FaqGetDTO> faqDto = _mapper.Map<List<FaqGetDTO>>(faqs);


        return faqDto;
    }

    public FaqGetDTO GetFaq(Func<Faq, bool>? func = null, params string[]? includes)
    {
        var faq = _faqRepository.GetEntity(func);
        FaqGetDTO faqDto = _mapper.Map<FaqGetDTO>(faq);


        return faqDto;
    }

	public void SoftDelete(int id)
	{
		var existFaq = _faqRepository.GetEntity(x => x.Id == id);
		if (existFaq == null) throw new EntityNotFoundException("Faq not found!");
		existFaq.DeletedDate = DateTime.UtcNow.AddHours(4);

		_faqRepository.SoftDelete(existFaq);
	}

	public void UpdateFaq(FaqUpdateDTO updateDTO)
    {
        var oldFaq = _faqRepository.GetEntity(x => x.Id == updateDTO.Id);
        if (oldFaq == null) throw new EntityNotFoundException("Faq tapilmadi");


        oldFaq.Question = updateDTO.Question;
        oldFaq.Answer = updateDTO.Answer;

        _faqRepository.Commit();
    }
}
