<template>
  <div class="indivKeep">
    <div class="modal fade" :id="'Modal' + keep.id" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel"
      aria-hidden="true">
      <div class="modal-dialog" role="document">
        <div class="modal-content">
          <div class="modal-header">
            <h5 class="modal-title" id="exampleModalLabel">{{keep.name}}</h5>
            <button type="button" class="close" data-dismiss="modal" aria-label="Close">
              <span aria-hidden="true">&times;</span>
            </button>
          </div>
          <div class="modal-body">
            <h1>hey</h1>
            <img class="img-fluid" :src="keep.img" />
            <div class="row justify-content-around">
              <div class="bg-primary"><i class="fas fa-eye">{{keep.views}}</i>
                <p> Views</p>
              </div>
              <div class="bg-primary"><i class="fas fa-praying-hands">{{keep.keeps}}</i>
                <p> Keeps</p>
              </div>
              <div class="bg-primary"><i class="fas fa-share">{{keep.shares}}</i>
                <p> Shares</p>
              </div>
            </div>
            <div class="modal-footer">
              <button type="button" class="btn btn-secondary" data-dismiss="modal">Close</button>
              <div class="dropdown">
                <button class="btn btn-primary dropdown-toggle" type="button" id="dropdownMenuButton"
                  data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                  Dropdown button
                </button>
                <div class="dropdown-menu" aria-labelledby="dropdownMenuButton">
                  <a v-for="vault in vaults" class="dropdown-item" href="#">{{vault.name}}</a>
                </div>
              </div>
            </div>
            </form>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>


<script>
  export default {
    name: 'indivKeep',
    props: ['keep'],
    data() {
      return {}
    },
    computed: {
      vaults() {
        return this.$store.state.vaults
      }
    },
    methods: {
      addCount(keep, toAdd) {
        this.keep[toAdd] += 1;
        let payload = {
          keepData: keep,
          choice: toAdd
        }
        this.$store.dispatch("addCount", payload)
      }
    },
    components: {}
  }
</script>


<style scoped>

</style>