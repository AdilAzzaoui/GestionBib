pipeline {
    agent any
    stages {
        stage('Check Dotnet Version') {
            steps {
                script {
                    sh 'dotnet --version'  // Cette commande vérifie si dotnet est accessible
                }
            }
        }
        // stage('Checkout') {
        //     steps {
        //         // Récupère le code source depuis le dépôt Git
        //         checkout scm
        //     }
        // }
        // stage('Restore') {
        //     steps {
        //         // Restaure les dépendances du projet
        //         sh 'dotnet restore'
        //     }
        // }
        // stage('Build') {
        //     steps {
        //         // Compile le projet
        //         sh 'dotnet build --configuration Release'
        //     }
        // }
        // stage('Test') {
        //     steps {
        //         // Exécute les tests unitaires et génère un rapport XML avec xUnit
        //         sh 'dotnet test --configuration Release --logger:xunit;LogFileName=TestResults/testresult.xml'
        //     }
        //     post {
        //         always {
        //             // Publie les résultats des tests avec xUnit
        //             xunit(
        //                 tools: [xUnitDotNetTestType(
        //                     pattern: 'TestResults/testresult.xml',
        //                     skipNoTestFiles: true,
        //                     failIfNotNew: false,
        //                     deleteOutputFiles: true,
        //                     stopProcessingIfError: true
        //                 )]
        //             )
        //         }
        //     }
        // }
        // stage('Publish') {
        //     steps {
        //         // Publie l'application
        //         sh 'dotnet publish --configuration Release --output publish'
        //     }
        // }
    }
}
