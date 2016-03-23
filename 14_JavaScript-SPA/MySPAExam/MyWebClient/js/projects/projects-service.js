(function () {

    function projectsService(data) {

        function getLatestProjects() {

            return data.get('api/projects')
                .then(function (tenTrips) {
                    return tenTrips;
                });

        }

        function getProjectDetails(id) {
            return data.get('api/projects/' + id)
        }

        function createProject(newProject) {
            return data.post('api/projects', newProject);
        }

        function filterProjects(filters) {
            return data.get('api/projects/all', filters)
        }

        function getProjectCollaborators(id) {
            return data.get('api/projects/collaborators/' + id)
        }

        function addProjectCollaborator(id, mail) {
            console.log(mail.toString());
            return data.put('api/projects/' + id, mail);
        }

        return {
            getLatestProjects: getLatestProjects,
            createProject: createProject,
            filterProjects: filterProjects,
            getProjectDetails: getProjectDetails,
            getProjectCollaborators: getProjectCollaborators,
            addProjectCollaborator: addProjectCollaborator
        }
    }

    angular.module('myApp.services')
        .factory('projectsService', ['data', projectsService]);

})();