# Use the official Node.js image as the base image
FROM node:18 as build

# Set the working directory in the container
WORKDIR /usr/src/app

# Copy the package.json and package-lock.json files to the container
COPY package*.json ./

# Install Angular CLI to run Build #
RUN npm install -g @angular/cli

# Install the app's dependencies
RUN npm install

# Copy the entire Angular app directory to the container
COPY . .

# Build the Angular app
RUN npm run build --omit=dev

RUN ng build

# Use a lightweight web server to serve the Angular app
FROM nginx:alpine

# Copy the built Angular app to the appropriate location in the Nginx container
COPY --from=build /usr/src/app/dist/conversion-app /usr/share/nginx/html

# Expose the default Nginx port
EXPOSE 80

# Start Nginx when the container starts
# CMD ["nginx", "-g", "daemon off;"]
