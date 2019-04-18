<template>
  <div class="Dashboard">
    <div class="row mt-5 justify-content-center">
      <div class="col-10 px-0 mt-4 border h-100" style="min-height:60vh">
        <div class="bg-info text-white h-25 text-left pl-3">
          <h1>Dashboard</h1>
        </div>
        <div class="row justify-content-center">
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
              <a class="nav-link" id="contact-tab" data-toggle="tab" href="#allkeeps" role="tab" aria-controls="contact"
                aria-selected="false">All Created Keeps</a>
            </li>
          </ul>
          <div class="tab-content" id="myTabContent">
            <div class="tab-pane fade" v-for="vault in vaults" :id="'vault' + vault.id" role="tabpanel"
              aria-labelledby="vault-details">
              <div class="row">
                <div class="col-2 border" v-if="activeKeeps != null" v-for="keep in activeKeeps"
                  style="max-width:200px">
                  <h5>
                    {{keep.name}}
                  </h5>
                  <h5>
                    {{keep.description}}
                  </h5>
                  <img class=" img-fluid" :src="keep.img" />
                  <button class=" btn btn-outline-danger" @click="remKeep(keep, vault)">Remove from Vault</button>
                </div>
              </div>
            </div>
            <div class="tab-pane fade" id="private" role="tabpanel" aria-labelledby="profile-tab">
              <div v-for="privateKeep in privateKeeps">{{private.name}}</div>
              <div v-for="privateKeep in privateKeeps">{{private.isPrivate}}</div>
            </div>
            <div class="tab-pane fade" id="allkeeps" role="tabpanel" aria-labelledby="contact-tab">
              hey
              <div v-for="keep in userKeeps">{{keep.name}}</div>
            </div>
          </div>
        </div>
      </div>
    </div>
  </div>

  </div>
</template>


<script>
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
        if (this.$store.state.private.length > 0) {
          return this.$store.state.private
        }
      },
      userKeeps() {
        return this.$store.state.keeps.filter(keep => keep.userId == this.$store.state.user.id)
      }
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
      }
    },
    watch: {
      counter() {
        console.log('The counter has changed!')
      }
    },
    components: {}
  }
</script>


<style scoped>

</style>