using sistem_za_evidenciju_vozila_i_putnih_naloga.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace sistem_za_evidenciju_vozila_i_putnih_naloga.Services
{
    public interface ITravelWarrantService
    {
        List<TWIndexVM> getAllTravelWarrants();
        TWCreateVM prepareTWCreateVM();
        int createTravelWarrant(TWCreateVM model);
        int deleteTravelWarrant(int travelWarrantId);
        TWDetailsVM getTravelWarrantDetails(int travelWarrantId);
        TWEditVM getTravelWarrantEditDetails(int travelWarrantId);
        TWSearchVM getTWSearchVM();
        List<TWSearchResultsVM> getTWSearchResultsVM(TWSearchVM model);
        bool editTravelWarrant(TWEditVM model);
    }
}
