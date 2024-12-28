pipeline {
    agent any
    environment {
        PATH = "/usr/local/share/dotnet:$PATH"  // Assurez-vous que le chemin vers dotnet est inclus
        DOCKER_IMAGE_NAME = 'adil1020111/gestionbibliotheque'  // Nom de l'image Docker (modifiez-le selon votre compte Docker Hub)
        DOCKER_TAG = 'latest'  // Tag de l'image Docker
        DOCKER_CREDENTIALS_ID = 'dockerhub-credentials'  // Identifiants Docker Hub dans Jenkins (modifiez selon votre configuration)
    }
    stages {
        stage('Check Dotnet Version') {
            steps {
                script {
                    // Vérifie la version de dotnet
                    sh 'dotnet --version'
                }
            }
        }
        stage('Restore Dependencies') {
            steps {
                script {
                    // Restaure les dépendances du projet
                    sh 'dotnet restore'
                }
            }
        }
        stage('Build Project') {
            steps {
                script {
                    // Compile le projet
                    sh 'dotnet build --configuration Release'
                }
            }
        }
        stage('Run Tests') {
            steps {
                script {
                    // Exécute les tests unitaires
                    sh 'dotnet test --configuration Release'
                }
            }
        }
        stage('Build Docker Image') {
            steps {
                script {
                    // Build l'image Docker à partir du Dockerfile
                    sh 'docker build -t $DOCKER_IMAGE_NAME:$DOCKER_TAG .'
                }
            }
        }
        stage('Login to Docker Hub') {
            steps {
                script {
                    // Se connecter à Docker Hub à l'aide des identifiants stockés dans Jenkins
                    withCredentials([usernamePassword(credentialsId: "$DOCKER_CREDENTIALS_ID", usernameVariable: 'DOCKER_USERNAME', passwordVariable: 'DOCKER_PASSWORD')]) {
                        sh 'docker login -u $DOCKER_USERNAME -p $DOCKER_PASSWORD'
                    }
                }
            }
        }
        stage('Push Docker Image') {
            steps {
                script {
                    // Pousse l'image sur Docker Hub
                    sh 'docker push $DOCKER_IMAGE_NAME:$DOCKER_TAG'
                }
            }
        }
    }
}
