using Autodoc.SeoAdmin.Application.Common.Interfaces;
using Autodoc.SeoAdmin.Application.Common.Interfaces.UrlHandling;
using Autodoc.SeoAdmin.Application.Common.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Autodoc.SeoAdmin.Infrastructure.Services
{
    public abstract class SeoUrlProccessorBase<T> : ISeoUrlProccessor<T>
    {
        protected readonly ISeoRawDataRepository<T> _seoRawDataRepository;
        protected readonly IConstructorsSequenceBuilder<T> _sequenceBuilder;
        protected readonly List<UrlCombinationModel> _combinedUrlModifications;
        protected readonly IGeneratedUrlWriter _generatedUrlsWriter;
        protected readonly IProccessStateService _poccessStateService;
        protected ProccessingStateModel _proccesStateModel;
        public abstract int PageType { get; }
        public SeoUrlProccessorBase (
            ISeoRawDataRepository<T> seoRawDataRepository,
            IConstructorsSequenceBuilder<T> sequenceBuilder,
            IProccessStateService poccessStateService,
            IGeneratedUrlWriter generatedUrlsWriter)
        {
            _poccessStateService = poccessStateService;
            _generatedUrlsWriter = generatedUrlsWriter;
            _seoRawDataRepository = seoRawDataRepository;
            _sequenceBuilder = sequenceBuilder;
            _combinedUrlModifications = new List<UrlCombinationModel>();
            _proccesStateModel = new ProccessingStateModel();
        }
        public async Task StartProccess ()
        {
            IEnumerable<T> rawUrlData = null;
            IUrlTransletiratorConstructor<T> mainConstructor = _sequenceBuilder.BuildChain();

            _proccesStateModel = await _poccessStateService.GetSavedState(PageType);

            do
            {
                rawUrlData = await _seoRawDataRepository.GetRawUrlData(_proccesStateModel.BatchSize, _proccesStateModel.BatchStep);

                rawUrlData.ToList().ForEach(i => _combinedUrlModifications.AddRange(mainConstructor.Handle(i)));

                //write generated urls batch into db
                await _generatedUrlsWriter.WriteGeneratedUrls(_combinedUrlModifications);
                await _poccessStateService.SaveProccessedState(_proccesStateModel);                  

                if (rawUrlData.Count() > 0)
                {
                    _proccesStateModel.IncrementBatchStep();
                }

            } while (rawUrlData.Count() > 0);
        }
    }
}
