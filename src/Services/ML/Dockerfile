# Create dockerfile for pythonapi
FROM python:3.8-slim-buster
WORKDIR /app
EXPOSE 5000

# Install dependencies
RUN pip install --upgrade pip
RUN pip install flask
RUN pip install flask_restful
RUN pip install pandas
RUN pip install numpy
RUN pip install matplotlib

# RUN pip install pickle
RUN pip install sklearn

# Copy files
COPY ["src/Services/ML/API", "/app/src"]
COPY ["src/Services/ML/Models", "/app/Models"]

WORKDIR /app/src

# Run the application
CMD ["python", "-m" , "flask", "run", "--host=0.0.0.0"]