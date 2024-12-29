pipeline {
    agent any
    environment {
        PATH = "/usr/local/share/dotnet:/usr/local/bin:$PATH"
        DOCKER_IMAGE_NAME = 'adil1020111/gestionbibliotheque'
        DOCKER_TAG = 'latest'
        DOCKER_CREDENTIALS_ID = 'dockerhub-credentials'
        AZURE_VM_IP = '20.188.47.31'
        AZURE_SSH_USER = 'adilazzaoui'
        AZURE_SSH_PRIVATE_KEY = credentials('azure-ssh-private-key')
    }
    stages {
        stage('Check Dotnet Version') {
            steps {
                script {
                    sh 'dotnet --version'
                }
            }
        }
        stage('Restore Dependencies') {
            steps {
                script {
                    sh 'dotnet restore'
                }
            }
        }
        stage('Build Project') {
            steps {
                script {
                    sh 'dotnet build --configuration Release'
                }
            }
        }
        stage('Run Tests') {
            steps {
                script {
                    sh 'dotnet test --configuration Release'
                }
            }
        }
        stage('Build Docker Image') {
            steps {
                script {
                    sh 'docker build -t $DOCKER_IMAGE_NAME:$DOCKER_TAG .'
                }
            }
        }
        stage('Login to Docker Hub') {
            steps {
                script {
                    withCredentials([usernamePassword(credentialsId: "$DOCKER_CREDENTIALS_ID", usernameVariable: 'DOCKER_USERNAME', passwordVariable: 'DOCKER_PASSWORD')]) {
                        sh 'docker login -u $DOCKER_USERNAME -p $DOCKER_PASSWORD'
                    }
                }
            }
        }
        stage('Push Docker Image') {
            steps {
                script {
                    sh 'docker push $DOCKER_IMAGE_NAME:$DOCKER_TAG'
                }
            }
        }
        stage('Deploy to Azure VM') {
            steps {
                script {
                    sh """
                        ssh -t -i \$AZURE_SSH_PRIVATE_KEY \$AZURE_SSH_USER@\${AZURE_VM_IP} "
                            # Stop and remove the existing container using the image if it exists
                            docker ps -q -f 'ancestor=\$DOCKER_IMAGE_NAME:\$DOCKER_TAG' | xargs -r docker stop
                            docker ps -q -f 'ancestor=\$DOCKER_IMAGE_NAME:\$DOCKER_TAG' | xargs -r docker rm
                            
                            # Pull the new Docker image and run the container
                            docker pull \$DOCKER_IMAGE_NAME:\$DOCKER_TAG
                            docker run -d -p 80:80 \$DOCKER_IMAGE_NAME:\$DOCKER_TAG
                        "
                    """
                }
            }
        }

    }
}
