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
          <li class="nav-item active">
            <a @click="goHome()" class="nav-link" href="#">Home <span class="sr-only">(current)</span></a>
          </li>
          <li class="nav-item">
            <a @click="goDashboard()" class="nav-link" href="#">Dashboard</a>
          </li>
          <form class="form-inline my-2 my-lg-0">
            <input class="form-control mr-sm-2" type="search" placeholder="Search" aria-label="Search">
            <button class="btn btn-outline-primary my-2 my-sm-0" type="submit">Search</button>
          </form>

          <!-- <li class="nav-item dropdown">
            <a class="nav-link dropdown-toggle" href="#" id="navbarDropdown" role="button" data-toggle="dropdown"
              aria-haspopup="true" aria-expanded="false">
              Dropdown
            </a>
            <div class="dropdown-menu" aria-labelledby="navbarDropdown">
              <a class="dropdown-item" href="#">Action</a>
              <a class="dropdown-item" href="#">Another action</a>
              <div class="dropdown-divider"></div>
              <a class="dropdown-item" href="#">Something else here</a>
            </div>
          </li> -->

        </ul>
        <span class=" p-0 justify-content-center float-right">
          <a>Create Keep <span class="sr-only">(current)</span></a>
          <i class="fas fa-plus-square makeVault add nav-link" data-toggle="modal" data-target="#exampleModal"
            style="font-size: 1.5em;"></i>
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
    computed: {},
    methods: {
      goHome() {
        this.$router.push({ name: "home" });
      },
      goDashboard() {
        this.$router.push({ name: "dashboard" });
      }
    },
    components: {}
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