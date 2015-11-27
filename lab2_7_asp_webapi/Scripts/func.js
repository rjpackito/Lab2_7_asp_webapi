var ViewModel = function () {
    var self = this;
    self.Cinemas = ko.observableArray();
    self.Cinema = ko.observableArray();
    self.Films = ko.observableArray();
    self.Film = ko.observableArray();
    self.error = ko.observable();
    self.Seances = ko.observableArray();
    self.Seance = ko.observableArray();
    self.Affiche = ko.observableArray();
    
    self.newCinema = {
        CinemaId: ko.observable(0),
        CinemaName: ko.observable(null)
    };
    self.newFilm = {
        FilmId: ko.observable(0),
        FilmName: ko.observable(null)
    };
    self.newSeance = {
        SeanceId: ko.observable(),
        FilmId: ko.observable(),
        CinemaId: ko.observable(),
        SeanceDT: ko.observable()
    };
    self.editCinemaId = ko.observable();
    self.editFilmId = ko.observable();
    self.editSeanceDT = ko.observable();
    self.view = ko.observable(true);
    self.edit = ko.observable(false);
    self.create = ko.observable(false);
    self.stringSearchCinema = ko.observable("");
    self.stringSearchFilm = ko.observable("");

    self.fromDT = ko.observable("");
    self.beforeDT = ko.observable("");
    var cinemasUri = '/api/Cinema';
    var filmUri = '/api/Film';
    var seanceUri = '/api/Seance';
    function ajaxHelper(uri, method, data) {
        self.error(''); // Clear error message
        return $.ajax({
            type: method,
            url: uri,
            dataType: 'json',
            contentType: 'application/json',
            data: data ? JSON.stringify(data) : null
        }).fail(function (jqXHR, textStatus, errorThrown) {
            self.error(errorThrown);
        });
    }
    //Cinemas
    function getAllCinemas() {
        ajaxHelper(cinemasUri, 'GET').done(function (data) {
            self.Cinemas(data);
        });
    }
    self.getCinema = function (item) {
        ajaxHelper(cinemasUri + '/' + item.CinemaId, 'GET').done(function (data) {
            self.view(false);
            self.create(false);
            self.edit(true);
            self.Cinema(data);
        });
    }
    self.addCinema = function (formElement) {
        var newCinema = {
            CinemaName: self.newCinema.CinemaName()
        };
        ajaxHelper(cinemasUri, 'POST', newCinema).done(function (item) {
            if (item[0]) {
                self.error(item[0]._errors[0]["<ErrorMessage>k__BackingField"]);
                return;
            }
            self.Cinemas.push(item);
            self.newCinema.CinemaName('');
           self.handleCancelClick();
        });
    }
    self.editCinema = function (formElement) {
        var updateCinema = {
            CinemaId: self.Cinema().CinemaId,
            CinemaName: self.Cinema().CinemaName
        };
        ajaxHelper(cinemasUri + '/' + updateCinema.CinemaId, 'PUT', updateCinema).done(function () {
            if (item[0]) {
                self.error(item[0]._errors[0]["<ErrorMessage>k__BackingField"]);
                return;
            }
            self.Cinemas.removeAll();
            getAllCinemas();
        });

    }
    self.deleteCinema = function (item) {
        ajaxHelper(cinemasUri + '/' + item.CinemaId, 'DELETE').done(function () {
            self.Cinemas.removeAll();
            getAllCinemas();
        });
    }

    //Films
    function getAllFilms() {
        ajaxHelper(filmUri, 'GET').done(function (data) {
            self.Films(data);
        });
    }
    self.getFilm = function (item) {
        ajaxHelper(filmUri + '/' + item.FilmId, 'GET').done(function (data) {
            self.view(false);
            self.create(false);
            self.edit(true);
            self.Film(data);
        });
    }
    self.addFilm = function (formElement) {
        var newFilm = {
            FilmName: self.newFilm.FilmName()
        };
        ajaxHelper(filmUri, 'POST', newFilm).done(function (item) {
            if (item[0]) {
                self.error(item[0]._errors[0]["<ErrorMessage>k__BackingField"]);
                return;
            }
       
            self.newFilm.FilmName('');
            self.handleCancelClick();
        });
    }
    self.editFilm = function (formElement) {
        var updateFilm = {
            FilmId: self.Film().FilmId,
            FilmName: self.Film().FilmName
        };
        ajaxHelper(filmUri + '/' + updateFilm.FilmId, 'PUT', updateFilm).done(function () {
            if (item[0]) {
                self.error(item[0]._errors[0]["<ErrorMessage>k__BackingField"]);
                return;
            }
            self.Films.removeAll();
            getAllFilms();
        });

    }
    self.deleteFilm = function (item) {
        ajaxHelper(filmUri + '/' + item.FilmId, 'DELETE').done(function () {
            self.Films.removeAll();
            getAllFilms();
        });
    }


    //Seances
    function getAllSeances() {
        ajaxHelper(seanceUri, 'GET').done(function (data) {
            self.Seances(data);
        });
        self.view(true);
    }
    function getAffiches() {
        ajaxHelper(seanceUri, 'GET').done(function (data) {
            self.Affiche(data);
        });
    }
    self.getSeance = function (item) {
        ajaxHelper(seanceUri + '/' + item.SeanceId, 'GET').done(function (data) {
            self.view(false);
            self.create(false);
            self.edit(true);
            self.Seance(data[0]);
            self.editCinemaId(self.Seance().CinemaId);
            self.editFilmId(self.Seance().FilmId);
            self.editSeanceDT(self.Seance().SeanceDT);
        });

    }
    self.addSeance = function (formElement) {
        var newSeance = {
            FilmId: self.newSeance.FilmId(),
            CinemaId: self.newSeance.CinemaId(),
            SeanceDT: self.newSeance.SeanceDT()
        };
        ajaxHelper(seanceUri, 'POST', newSeance).done(function (item) {
            self.Films.push(item);
        });
        self.Seances.removeAll();
        getAllSeances();
        self.handleCancelClick();
    }
    self.editSeance = function (formElement) {
        var updateSeance = {
            SeanceId: self.Seance().SeanceId,
            FilmId: self.editFilmId(),
            CinemaId: self.editCinemaId(),
            SeanceDT: self.editSeanceDT()
        };
        ajaxHelper(seanceUri + '/' + updateSeance.SeanceId, 'PUT', updateSeance).done(function () {
            self.Seances.removeAll();
            getAllSeances();

        });
    }
    self.handleCreateClick = function () {
        self.view(false);
        self.edit(false);
        self.create(true);
    }
    self.handleCancelClick = function () {
        self.edit(false);
        self.create(false);
        self.view(true);
    }
    self.deleteSeance = function (item) {
        ajaxHelper(seanceUri + '/' + item.SeanceId, 'DELETE').done(function () {
            self.Seances.removeAll();
            getAllSeances();
        });
    }

    self.SearchCinema = function () {
        self.Affiche.removeAll();
        self.Affiche(ko.utils.arrayFilter(self.Seances(), function (s) { return s.CinemaName == self.stringSearchCinema(); }));
        self.stringSearchCinema('');
    }
    self.SearchFilm = function () {
        self.Affiche.removeAll();
        self.Affiche(ko.utils.arrayFilter(self.Seances(), function (s) { return s.FilmName == self.stringSearchFilm(); }));
        self.stringSearchFilm('');
    }
    self.SearchDT = function () {
        self.Affiche.removeAll();
        self.Affiche(ko.utils.arrayFilter(self.Seances(), function (s) { return (self.fromDT()<=s.SeanceDT && self.beforeDT()>=s.SeanceDT); }));
        self.fromDT('');
        self.beforeDT('');
    }
    self.AllAffiche=function(){
        getAffiches();
    }
    getAllCinemas();
    getAllFilms();
    getAllSeances();
    getAffiches();
};

ko.applyBindings(new ViewModel());
