<template>
  <div class="Auth">
    <div class="modal fade" id="MyModal" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel"
      aria-hidden="true">
      <div class="modal-dialog modal-lg" role="document">
        <div class="modal-content">
          <div class="modal-header p-0">
            <div class="tabbable w-100" style="height:100%">
              <ul class="nav nav-tabs w-100 h-100" role="tablist">
                <li class="nav-item active w-50">
                  <a class="nav-link p-4 text active" style="color:white" href="#login" id="#login" data-toggle="tab">
                    Login
                  </a>
                </li>
                <li class="nav-item active w-50">
                  <a class="nav-link p-4 text" style="color:white" href="#register" id="#register" data-toggle="tab">
                    Register
                  </a>
                </li>
              </ul>
            </div>
          </div>
          <div class="tab-content m-5" id="myTabContent">
            <div class="tab-pane mt-5 fade text-dark active show" href="#login" id="login" role="tabpanel"
              aria-labelledby="profile-tab">
              <div class="login">
                <img src="../src/assets/keepr.png" />
                <form @submit.prevent="loginUser">
                  <div class="input-group my-4">
                    <div class="input-group-prepend">
                      <div class="input-group-text bgBlue bordR text-white">Email</div>
                    </div>
                    <input class="form-control" type="email" v-model="creds.email" placeholder="email">
                  </div>
                  <div class="input-group my-4">
                    <div class="input-group-prepend">
                      <div class="input-group-text bgPurp bordR text-white">Password</div>
                    </div>
                    <input class="form-control" type="password" v-model="creds.password" placeholder="password">
                  </div>
                  <button class="btn bgBlack bordR text-white" type="submit">Login</button>
                </form>
              </div>
            </div>
            <div class="tab-pane fade text-dark" href="#register" id="register" role="tabpanel"
              aria-labelledby="profile-tab">
              <form @submit.prevent="register">
                <div class="register">
                  <img src="../src/assets/keepr.png" />
                  <div class="input-group my-4">
                    <div class="input-group-prepend">
                      <div class="input-group-text bgBlue bordR text-white">Name</div>
                    </div>
                    <input class="form-control" type="email" v-model="newUser.name" placeholder="name">
                  </div>
                  <div class="input-group my-4">
                    <div class="input-group-prepend">
                      <div class="input-group-text bgBlue bordR text-white">Email</div>
                    </div>
                    <input class="form-control" type="email" v-model="newUser.email" placeholder="email">
                  </div>
                  <div class="input-group my-4">
                    <div class="input-group-prepend">
                      <div class="input-group-text bgPurp bordR text-white">Password</div>
                    </div>
                    <input class="form-control" type="password" v-model="newUser.password" placeholder="password">
                  </div>
                  <button class="btn bgBlack bordR text-white" type="submit">Register</button>
                </div>
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
    name: 'Auth',
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
    background-color: black;
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

  .bgBlack {
    background-color: black;
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

  .nav-tabs .nav-link.active {
    color: white;
    background-color: #fc0095;
  }
</style>