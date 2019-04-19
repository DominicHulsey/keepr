<template>
  <div class="Navigationbar">
    <nav class="navbar sticky-top navbar-expand-lg navbar-light bg-navbar">
      <a class="navbar-brand" href="#">Keepr™</a>
      <button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarSupportedContent"
        aria-controls="navbarSupportedContent" aria-expanded="false" aria-label="Toggle navigation">
        <span class="navbar-toggler-icon"></span>
      </button>
      <div class="collapse navbar-collapse" id="navbarSupportedContent">
        <ul class="navbar-nav mr-auto">
          <li class="nav-item active mx-4">
            <a @click="goHome()" class="nav-link" href="#">Home </a>
          </li>
          <li class="nav-item mx-4">
            <a @click="goDashboard()" class="nav-link" href="#">Dashboard</a>
          </li>
          <li class="nav-item mx-4">
            <a class="nav-link add" @click="logout()">Logout</a>
          </li>
          <!-- <form class="form-inline my-2 my-lg-0">
            <input class="form-control mr-sm-2" type="search" placeholder="Search" aria-label="Search">
            <button class="btn btn-outline-primary my-2 my-sm-0" type="submit">Search</button>
          </form> -->
        </ul>

        <span v-if="!this.loggedIn">
          <div class="nav-link add rounded" @click="login()" style="font-size: 1.5em;border:3px solid black">
            <a>Create Keep <i class="fas fa-plus"></i> </a>
          </div>
        </span>
        <span v-else>
          <div class="nav-link add rounded" data-toggle="modal" data-target="#exampleModal"
            style="font-size: 1.5em;border:3px solid black">
            <a>Create Keep <i class="fas fa-plus"></i> </a>
          </div>
        </span>
      </div>
    </nav>
  </div>
</template>


<script>
  export default {
    name: 'Navbar',
    data() {
      return {}
    },
    computed: {
      loggedIn() {
        return this.$store.state.user.id
      }
    },
    methods: {
      goHome() {
        this.$router.push({ name: "home" });
      },
      login() {
        $('#MyModal').modal('show');
      },
      goDashboard() {
        if (this.loggedIn) {
          this.$router.push({ name: "dashboard" });
        }
        else {
          $('#MyModal').modal('show');
        }
      },
      logout() {
        this.$store.dispatch("logout")
      }
    },
  }
</script>


<style scoped>
  .bg-navbar {
    background-color: #eaebeb;
  }

  .add {
    cursor: pointer;
  }
</style>