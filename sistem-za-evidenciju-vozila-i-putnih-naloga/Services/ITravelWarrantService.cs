using sistem_za_evidenciju_vozila_i_putnih_naloga.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using X.PagedList;

namespace sistem_za_evidenciju_vozila_i_putnih_naloga.Services
{
    public interface ITravelWarrantService
    {
        IPagedList<TWIndexVM> getAllTravelWarrants(int? pageNumber, string sortOrder);
        TWCreateVM prepareTWCreateVM();
        bool createTravelWarrant(TWCreateVM model);
        int deleteTravelWarrant(int travelWarrantId);
        TWDetailsVM getTravelWarrantDetails(int travelWarrantId);
        TWEditVM getTravelWarrantEditDetails(int travelWarrantId);
        TWSearchVM getTWSearchVM();
        List<TWSearchResultsVM> getTWSearchResultsVM(TWSearchVM model);
        bool editTravelWarrant(TWEditVM model);
    }
}
