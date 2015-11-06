var ViewModel = function () {
    var self = this;
    self.cinemas = ko.observableArray();
    self.cinema = ko.observableArray();
    self.films = ko.observableArray();
    self.film = ko.observableArray();
    self.error = ko.observable();
    self.seances = ko.observableArray();
    self.seance = ko.observableArray();
    self.Affiche = ko.observableArray();
    
    self.newcinema = {
        CinemaId: ko.observable(),
        CinemaName: ko.observable()
    };
    self.newfilm = {
        FilmId: ko.observable(),
        FilmName: ko.observable("")
    };
    self.newseance = {
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
            self.cinemas(data);
        });
    }
    self.getCinema = function (item) {
        ajaxHelper(cinemasUri + '/' + item.CinemaId, 'GET').done(function (data) {
            self.view(false);
            self.create(false);
            self.edit(true);
            self.cinema(data);
        });
    }
    self.addCinema = function (formElement) {
        var cinema = {
            CinemaName: self.newcinema.CinemaName()
        };
        ajaxHelper(cinemasUri, 'POST', cinema).done(function (item) {
            if (item == undefined) {
                self.error("Введены некорректные данные");
                self.handleCancelClick();
                return;
            }
            self.cinemas.push(item);
            self.newcinema.CinemaName('');
           self.handleCancelClick();
        });
    }
    self.editCinema = function (formElement) {
        var updateCinema = {
            CinemaId: self.cinema().CinemaId,
            CinemaName: self.cinema().CinemaName
        };
        ajaxHelper(cinemasUri + '/' + updateCinema.CinemaId, 'PUT', updateCinema).done(function () {
            if (item == undefined) {
                self.error("Введены некорректные данные");
                self.handleCancelClick();
                return;
            }
            self.cinemas.removeAll();
            getAllCinemas();
        });

    }
    self.deleteCinema = function (item) {
        ajaxHelper(cinemasUri + '/' + item.CinemaId, 'DELETE').done(function () {
            self.cinemas.removeAll();
            getAllCinemas();
        });
    }

    //Films
    function getAllFilms() {
        ajaxHelper(filmUri, 'GET').done(function (data) {
            self.films(data);
        });
    }
    self.getFilm = function (item) {
        ajaxHelper(filmUri + '/' + item.FilmId, 'GET').done(function (data) {
            self.view(false);
            self.create(false);
            self.edit(true);
            self.film(data);
        });
    }
    self.addFilm = function (formElement) {
        var film = {
            FilmName: self.newfilm.FilmName()
        };
        ajaxHelper(filmUri, 'POST', film).done(function (item) {
            if (item == undefined) {
                self.error("Введены некорректные данные");
                    self.handleCancelClick();
                    return;
            }
       
            self.newfilm.FilmName('');
            self.handleCancelClick();
        });
    }
    self.editFilm = function (formElement) {
        var updateFilm = {
            FilmId: self.film().FilmId,
            FilmName: self.film().FilmName
        };
        ajaxHelper(filmUri + '/' + updateFilm.FilmId, 'PUT', updateFilm).done(function () {
            if (item == undefined) {
                self.error("Введены некорректные данные");
                self.handleCancelClick();
                return;
            }
            self.films.removeAll();
            getAllFilms();
        });

    }
    self.deleteFilm = function (item) {
        ajaxHelper(filmUri + '/' + item.FilmId, 'DELETE').done(function () {
            self.films.removeAll();
            getAllFilms();
        });
    }


    //Seances
    function getAllSeances() {
        ajaxHelper(seanceUri, 'GET').done(function (data) {
            self.seances(data);
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
            self.seance(data[0]);
            self.editCinemaId(self.seance().CinemaId);
            self.editFilmId(self.seance().FilmId);
            self.editSeanceDT(self.seance().SeanceDT);
        });

    }
    self.addSeance = function (formElement) {
        var seance = {
            FilmId: self.newseance.FilmId(),
            CinemaId: self.newseance.CinemaId(),
            SeanceDT: self.newseance.SeanceDT()
        };
        ajaxHelper(seanceUri, 'POST', seance).done(function (item) {
            self.films.push(item);
        });
        self.seances.removeAll();
        getAllSeances();
        self.handleCancelClick();
    }
    self.editSeance = function (formElement) {
        var updateSeance = {
            SeanceId: self.seance().SeanceId,
            FilmId: self.editFilmId(),
            CinemaId: self.editCinemaId(),
            SeanceDT: self.editSeanceDT()
        };
        ajaxHelper(seanceUri + '/' + updateSeance.SeanceId, 'PUT', updateSeance).done(function () {
            self.seances.removeAll();
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
            self.seances.removeAll();
            getAllSeances();
        });
    }

    self.SearchCinema = function () {
        self.Affiche.removeAll();
        self.Affiche(ko.utils.arrayFilter(self.seances(), function (s) { return s.CinemaName == self.stringSearchCinema(); }));
        self.stringSearchCinema('');
    }
    self.SearchFilm = function () {
        self.Affiche.removeAll();
        self.Affiche(ko.utils.arrayFilter(self.seances(), function (s) { return s.FilmName == self.stringSearchFilm(); }));
        self.stringSearchFilm('');
    }
    self.SearchDT = function () {
        self.Affiche.removeAll();
        self.Affiche(ko.utils.arrayFilter(self.seances(), function (s) { return (self.fromDT()<=s.SeanceDT && self.beforeDT()>=s.SeanceDT); }));
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
