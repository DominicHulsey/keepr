<template>
  <div class="Dashboard">
    <login-modal></login-modal>
    <div class="row mt-5 justify-content-center">
      <div class="col-10 px-0 mt-4 h-100" style="min-height:60vh;border:4px solid black;">
        <div class="text-white h-25 text-left pl-3" style="background-color:#9854bb;border-bottom:4px solid black;">
          <h1>Dashboard</h1>
        </div>
        <div class="row justify-content-center m-0">
          <ul class="nav mx-5 nav-tabs justify-content-between" id="myTab" role="tablist" style="width:100%">
            <li class="nav-item dropdown" style="width:33%">
              <a class="nav-link dropdown-toggle" data-toggle="dropdown" href="#" role="button" aria-haspopup="true"
                aria-expanded="false">Vaults</a>
              <div class="dropdown-menu">
                <a class="dropdown-item" id="vault-details" data-toggle="tab" aria-controls="vaults" role="tab"
                  v-for="vault in vaults" :href="'#vault' + vault.id" @click="setActive(vault)">{{vault.name}}</a>
                <div class="dropdown-divider"></div>
              </div>
            </li>
            <li class="nav-item" style="width:33%">
              <a class="nav-link" @click="getPrivate" id="profile-tab" data-toggle="tab" href="#private" role="tab"
                aria-controls="profile" aria-selected="false">Private Keeps</a>
            </li>
            <li class="nav-item" style="width:33%">
              <a class="nav-link active" id="contact-tab" data-toggle="tab" href="#allkeeps" role="tab"
                aria-controls="contact" aria-selected="false">All Created Keeps</a>
            </li>
          </ul>
          <div class="tab-content" id="myTabContent">
            <div class="tab-pane fade" v-for="vault in vaults" :id="'vault' + vault.id" role="tabpanel"
              aria-labelledby="vault-details">
              <div class="row d-flex justify-content-center flex-row m-0">
                <div class="col-2 Shadoww  m-2 w-100 card border p-0" style="border-radius:0 !important;"
                  v-for="keep in activeKeeps">
                  <img class="img-fluid" :src="keep.img" style="width:100%" />
                  <p class="m-0">
                    {{keep.name}}
                  </p>
                  <p class="m-0">
                    {{keep.description}}
                  </p>
                  <div>
                    <button class="btn w-50 trash" @click="deleteKeep(keep)"><i
                        class="fas fa-trash-alt fa-2x"></i></button>
                  </div>
                </div>
              </div>
              <button class="btn bgPurp bordR" @click="deleteVault(vault)">Delete Vault</button>
            </div>
            <div class="tab-pane fade" id="private" role="tabpanel" aria-labelledby="profile-tab">
              <div class="row d-flex justify-content-center flex-row m-0">
                <div class="col-2 Shadoww  m-2 w-100 card border p-0" style="border-radius:0 !important;"
                  v-for="keep in privateKeeps">
                  <img class="img-fluid" :src="keep.img" style="width:100%" />
                  <p class="m-0">
                    {{keep.name}}
                  </p>
                  <p class="m-0">
                    {{keep.description}}
                  </p>
                  <div>
                    <button class="btn w-50 trash" @click="deleteKeep(keep)"><i
                        class="fas fa-trash-alt fa-2x"></i></button>
                  </div>
                </div>
              </div>
            </div>
            <div class="tab-pane fade-in active" id="allkeeps" role="tabpanel" aria-labelledby="contact-tab">
              <div class="row d-flex justify-content-center flex-row m-0">
                <div class="col-2 Shadoww  m-2 w-100 card border p-0" style="border-radius:0 !important;"
                  v-for="keep in userKeeps">
                  <img class="img-fluid" :src="keep.img" style="width:100%" />
                  <p class="m-0">
                    {{keep.name}}
                  </p>
                  <p class="m-0">
                    {{keep.description}}
                  </p>
                  <div>
                    <button class="btn w-50 trash" @click="deleteKeep(keep)"><i
                        class="fas fa-trash-alt fa-2x"></i></button>
                  </div>
                </div>
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
  import LoginModal from "/Users/dominichulsey/source/codeworks/keepr/wwwsrc/components/loginModal.vue"
  export default {
    name: 'Dashboard',
    data() {
      return {
        activeKeeps: null
      }
    },
    computed: {
      vaults() {
        return this.$store.state.vaults
      },
      privateKeeps() {
        return this.$store.state.privateKeeps
      },
      userKeeps() {
        return this.$store.state.keeps.filter(keep => keep.userId == this.$store.state.user.id)
      },
    },
    methods: {
      setActive(vault) {
        this.activeKeeps = this.$store.state.vaultkeeps[vault.id]
      },
      remKeep(keep, vault) {
        let payload = {
          keepId: keep.id,
          vaultId: vault.id
        }
        this.$store.dispatch("remFromVault", payload)
        this.setActive(vault)
      },
      getPrivate() {
        if (this.$store.state.private == [])
          debugger
        this.$store.dispatch("getPrivate")
      },
      deleteKeep(keep) {
        this.$store.dispatch("deleteKeep", keep.id)
      },
      deleteVault(vault) {
        this.$store.dispatch("deleteVault", vault.id)
      }
    },
    components: {
      LoginModal
    }
  }
</script>


<style scoped>
  .trash {
    color: grey;
    border: none;
    transition: all 0.3s ease-in-out;
  }

  .trash:hover {
    transform: scale(1.03);
  }

  .Shadoww {
    box-shadow: -9px 8px 5px 1px rgba(153, 153, 153, 1);
  }
</style>