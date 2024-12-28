pipeline {
    agent any
    stages {
        stage('Checkout') {
            steps {
                // Récupère le code source depuis le dépôt Git
                checkout scm
            }
        }
        stage('Restore') {
            steps {
                // Restaure les dépendances du projet
                bat 'dotnet restore'
            }
        }
        stage('Build') {
            steps {
                // Compile le projet
                bat 'dotnet build --configuration Release'
            }
        }
        stage('Test') {
            steps {
                // Exécute les tests unitaires et génère un rapport XML avec xUnit
                bat 'dotnet test --configuration Release --logger:xunit'
            }
            post {
                always {
                    // Publie les résultats des tests avec xUnit
                    xunit(
                        testTimeMargin: '3000',
                        thresholdMode: 1,
                        thresholds: [
                            skipped(unstableThreshold: '0'),
                            failed(unstableThreshold: '0')
                        ],
                        tools: [
                            CheckType(
                                pattern: '**/TestResults/**/*.xml',
                                skipNoTestFiles: true
                            )
                        ]
                    )
                }
            }
        }
        stage('Publish') {
            steps {
                // Publie l'application
                bat 'dotnet publish --configuration Release --output publish'
            }
        }
    }
}
