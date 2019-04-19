<template>
  <div class="Navbar">
    <div class="modal fade" id="MyModal" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel"
      aria-hidden="true">
      <div class="modal-dialog modal-lg" role="document">
        <div class="modal-content">
          <div class="modal-header">
            <div class="tabbable w-100">
              <ul class="nav nav-tabs w-100" role="tablist">
                <li class="nav-item active w-50">
                  <a class="nav-link active" id="#login" href="#login" data-toggle="tab">
                    Login
                  </a>
                </li>
                <li class="nav-item active w-50">
                  <a class="nav-link" id="#register" href="#register" data-toggle="tab">
                    Register
                  </a>
                </li>
                <!-- <li class="nav-item dropdown">
                  <a class="nav-link dropdown-toggle" data-toggle="dropdown" href="">
                    Menu
                  </a>
                  <ul class="dropdown-menu">
                    <li>
                      <a class="dropdown-item" href="#News">
                        News
                      </a>
                    </li>
                  </ul>
                </li> -->
              </ul>
            </div>
          </div>
          <div class="tab-content" id="myTabContent">
            <div class="tab-pane fade text-dark active show" href="#login" id="login" role="tabpanel"
              aria-labelledby="profile-tab">
              <div class="login">
                <form @submit.prevent="loginUser">
                  <input type="email" v-model="creds.email" placeholder="email">
                  <input type="password" v-model="creds.password" placeholder="password">
                  <button type="submit">Login</button>
                </form>
                <p>Already have an account? Sign in here.</p>
              </div>
            </div>
            <div class="tab-pane fade text-dark" href="#register" id="register" role="tabpanel"
              aria-labelledby="profile-tab">
              <form @submit.prevent="register">
                <input type="text" v-model="newUser.username" placeholder="name">
                <input type="email" v-model="newUser.email" placeholder="email">
                <input type="password" v-model="newUser.password" placeholder="password">
                <button type="submit">Create Account</button>
                <p v-if="loginForm">No account Click to Register</p>
              </form>
            </div>
          </div>
        </div>
      </div>
    </div>
  </div>
  </div>
  </div>
</template>


<script>
  import Login from "/Users/dominichulsey/source/codeworks/keepr/wwwsrc/src/views/Login.vue"
  export default {
    name: 'Navbar',
    data() {
      return {
        loginForm: true,
        creds: {
          email: "",
          password: ""
        },
        newUser: {
          email: "",
          password: "",
          username: ""
        }
      };
    },
    computed: {},
    methods: {
      register() {
        this.$store.dispatch("register", this.newUser);
      },
      loginUser() {
        this.$store.dispatch("login", this.creds);
      }
    },
    components: {
      Login
    }
  }
</script>


<style scoped>
  .active {
    background-color: rgba(104, 104, 104, 0.687);
    color: white;
    transition: all 0.3s linear;
    border-radius: none !important;
  }

  .modal-content {
    border-top-left-radius: 0;
    border-top-right-radius: 0;
    border-bottom-right-radius: 0;
    border-bottom-left-radius: 0;
  }

  #login {
    background-color: white;
  }

  #register {
    background-color: white;
  }

  .nav-tabs .nav-link {
    border-top-left-radius: 0;
    border-top-right-radius: 0;
  }
</style>