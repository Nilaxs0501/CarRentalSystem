// ===================== Global Variables =====================
let currentUser = null;
let cars = [
  { 
    id: 1, 
    name: "BMW M8", 
    specs: ["Petrol", "Coupe", "600 HP"], 
    price: 1200, 
    available: true,
    image: "https://images.unsplash.com/photo-1580273916550-e323be2ae537?auto=format&fit=crop&w=800&q=80"
  },
  { 
    id: 2, 
    name: "Mercedes S-Class", 
    specs: ["Diesel", "Sedan", "500 HP"], 
    price: 900, 
    available: true,
    image: "https://images.unsplash.com/photo-1563720223880-4d93eef1f1c2?auto=format&fit=crop&w=800&q=80"
  },
  { 
    id: 3, 
    name: "Lamborghini Aventador", 
    specs: ["Petrol", "Supercar", "770 HP"], 
    price: 2500, 
    available: true,
    image: "https://images.unsplash.com/photo-1544829099-b9a0c07fad1a?auto=format&fit=crop&w=800&q=80"
  },
  { 
    id: 4, 
    name: "Porsche 911", 
    specs: ["Petrol", "Coupe", "580 HP"], 
    price: 1500, 
    available: true,
    image: "https://images.unsplash.com/photo-1503376780353-7e6692767b70?auto=format&fit=crop&w=800&q=80"
  },
  { 
    id: 5, 
    name: "Audi R8", 
    specs: ["Petrol", "Supercar", "602 HP"], 
    price: 1800, 
    available: false,
    image: "https://images.unsplash.com/photo-1617814076367-b759c7d7e738?auto=format&fit=crop&w=800&q=80"
  },
  { 
    id: 6, 
    name: "Range Rover Sport", 
    specs: ["Diesel", "SUV", "523 HP"], 
    price: 1100, 
    available: true,
    image: "https://images.unsplash.com/photo-1621007947382-bb3c3994e3fb?auto=format&fit=crop&w=800&q=80"
  }
];

// Initialize localStorage data if not exists
if (!localStorage.getItem('cars')) {
  localStorage.setItem('cars', JSON.stringify(cars));
}

if (!localStorage.getItem('users')) {
  const users = [
    { id: 1, username: "admin", password: "admin123", role: "admin", name: "Administrator", rentals: [] },
    { id: 2, username: "user", password: "user123", role: "customer", name: "John Doe", rentals: [] }
  ];
  localStorage.setItem('users', JSON.stringify(users));
}

if (!localStorage.getItem('rentals')) {
  localStorage.setItem('rentals', JSON.stringify([]));
}

// ===================== DOM Content Loaded =====================
document.addEventListener("DOMContentLoaded", function() {
  initializeApp();
});

function initializeApp() {
  // Preloader
  const preloader = document.getElementById("preloader");
  const startButton = document.getElementById("startButton");
  
  startButton.addEventListener("click", function() {
    preloader.style.display = "none";
    document.getElementById("main-content").style.opacity = "1";
  });
  
  // Check if user is already logged in
  const savedUser = localStorage.getItem('currentUser');
  if (savedUser) {
    currentUser = JSON.parse(savedUser);
    updateUIAfterLogin();
  }
  
  // Render cars
  renderCars();
  
  // Event listeners
  document.getElementById("loginBtn").addEventListener("click", openLoginModal);
  document.querySelector(".close-modal").addEventListener("click", closeLoginModal);
  document.getElementById("loginSubmit").addEventListener("click", login);
  document.getElementById("themeBtn").addEventListener("click", toggleTheme);
  document.getElementById("offersBtn").addEventListener("click", showOffers);
  document.getElementById("historyBtn").addEventListener("click", showHistory);
  
  // Close modal when clicking outside
  window.addEventListener("click", function(event) {
    const modal = document.getElementById("loginModal");
    if (event.target === modal) {
      closeLoginModal();
    }
  });
  
  // Contact form submission
  const contactForm = document.querySelector(".contact-form");
  if (contactForm) {
    contactForm.addEventListener("submit", function(e) {
      e.preventDefault();
      alert("Thank you for your message! We'll get back to you soon.");
      contactForm.reset();
    });
  }
  
  // Profile dropdown
  const profilePic = document.getElementById("profilePic");
  if (profilePic) {
    profilePic.addEventListener("click", function() {
      document.getElementById("profileDropdown").classList.toggle("active");
    });
  }
}

// ===================== Render Cars =====================
function renderCars() {
  const container = document.getElementById("carList");
  if (!container) return;
  
  const carsData = JSON.parse(localStorage.getItem('cars')) || cars;
  container.innerHTML = "";
  
  carsData.forEach((car, idx) => {
    const card = document.createElement("div");
    card.classList.add("car-card");
    card.innerHTML = `
      ${!car.available ? '<div class="badge">Rented</div>' : '<div class="badge">Premium</div>'}
      <div class="car-image"><img src="${car.image}" alt="${car.name}"></div>
      <div class="car-details">
        <h3>${car.name}</h3>
        <div class="car-specs">${car.specs.join(" | ")}</div>
        <div class="price">$${car.price}/day</div>
        <button class="rent-button" onclick="openRentModal(${car.id})" ${!car.available ? 'disabled style="opacity:0.5;"' : ''}>
          ${car.available ? 'Rent Now' : 'Not Available'}
        </button>
      </div>
    `;
    
    // 3D tilt mouse effect
    card.addEventListener("mousemove", function(e) {
      if (window.innerWidth < 768) return; // Disable on mobile
      
      let rect = card.getBoundingClientRect();
      let x = e.clientX - rect.left;
      let y = e.clientY - rect.top;
      let cx = rect.width / 2;
      let cy = rect.height / 2;
      let dx = (x - cx) / cx;
      let dy = (y - cy) / cy;
      
      card.style.transform = `rotateY(${dx * 10}deg) rotateX(${-dy * 10}deg) translateZ(0)`;
    });
    
    card.addEventListener("mouseleave", function() {
      card.style.transform = "rotateY(0deg) rotateX(0deg)";
    });
    
    container.appendChild(card);
  });
}

// ===================== Login Functions =====================
function openLoginModal() {
  document.getElementById("loginModal").classList.add("active");
}

function closeLoginModal() {
  document.getElementById("loginModal").classList.remove("active");
}

function login() {
  const username = document.getElementById("username").value;
  const password = document.getElementById("password").value;
  
  if (!username || !password) {
    alert("Please enter both username and password");
    return;
  }
  
  const users = JSON.parse(localStorage.getItem('users'));
  const user = users.find(u => u.username === username && u.password === password);
  
  if (user) {
    currentUser = user;
    localStorage.setItem('currentUser', JSON.stringify(user));
    updateUIAfterLogin();
    closeLoginModal();
    
    // Show welcome message
    alert(`Welcome back, ${user.name}!`);
  } else {
    alert("Invalid credentials. Please try again.");
  }
}

function updateUIAfterLogin() {
  document.getElementById("loginBtn").style.display = "none";
  document.getElementById("profileMenu").style.display = "flex";
  document.getElementById("profilePic").src = `https://i.pravatar.cc/40?u=${currentUser.username}`;
  
  // Update dashboard link if on dashboard pages
  if (document.getElementById("dashboardGreeting")) {
    document.getElementById("dashboardGreeting").textContent = `Welcome, ${currentUser.name}`;
  }
}

function logout() {
  currentUser = null;
  localStorage.removeItem('currentUser');
  
  document.getElementById("loginBtn").style.display = "inline-block";
  document.getElementById("profileMenu").style.display = "none";
  
  // If on a dashboard page, redirect to home
  if (window.location.pathname.includes("admin.html") || 
      window.location.pathname.includes("user.html") ||
      window.location.pathname.includes("payment.html")) {
    window.location.href = "index.html";
  }
}

// ===================== Dashboard Navigation =====================
function goToDashboard() {
  if (!currentUser) {
    alert("Please log in first");
    return;
  }
  
  if (currentUser.role === "admin") {
    window.location.href = "admin.html";
  } else {
    window.location.href = "user.html";
  }
}

// ===================== Utility Functions =====================
function toggleTheme() {
  document.body.classList.toggle("light-mode");
  
  // Save theme preference
  const isLightMode = document.body.classList.contains("light-mode");
  localStorage.setItem("theme", isLightMode ? "light" : "dark");
}

function scrollToSection(sectionId) {
  const section = document.getElementById(sectionId);
  if (section) {
    section.scrollIntoView({ behavior: "smooth" });
  }
}

function showOffers() {
  alert("Special offers: Get 10% off on weekly rentals! Use code: LUXURY10");
}

function showHistory() {
  if (!currentUser) return;
  
  const rentals = JSON.parse(localStorage.getItem('rentals')) || [];
  const userRentals = rentals.filter(r => r.userId === currentUser.id);
  
  if (userRentals.length === 0) {
    alert("You haven't made any rentals yet.");
    return;
  }
  
  let historyMessage = "Your rental history:\n\n";
  userRentals.forEach(rental => {
    historyMessage += `Car: ${rental.carName}\n`;
    historyMessage += `Dates: ${rental.startDate} to ${rental.endDate}\n`;
    historyMessage += `Total: $${rental.totalPrice}\n`;
    historyMessage += `Status: ${rental.status}\n\n`;
  });
  
  alert(historyMessage);
}

function openRentModal(carId) {
  if (!currentUser) {
    openLoginModal();
    return;
  }
  
  const carsData = JSON.parse(localStorage.getItem('cars')) || cars;
  const car = carsData.find(c => c.id === carId);
  
  if (!car.available) {
    alert("This car is currently not available for rent.");
    return;
  }
  
  // For now, just show an alert. In a real app, this would open a modal with a form.
  alert(`You are about to rent: ${car.name}\nPrice: $${car.price}/day\n\nYou will be redirected to the payment page.`);
  
  // Store selected car in sessionStorage for the payment page
  sessionStorage.setItem('selectedCar', JSON.stringify(car));
  
  // Redirect to payment page
  window.location.href = "payment.html";
}

// Initialize theme from localStorage
const savedTheme = localStorage.getItem("theme");
if (savedTheme === "light") {
  document.body.classList.add("light-mode");
}